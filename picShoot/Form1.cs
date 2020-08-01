using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace picShoot {
    public partial class Form1 : Form {
        public bool IsRelease = true;

        private int cameraNo;
        public VideoCapture capture;
        private int spinAngle;
        private int resIndex;
        private int shootCount;
        private Mat currentFrame;
        private int camWidth;
        private int camHeigh;
        private string saveDir;
        private string useComport;
        private bool isStartCapture;
        private string savePath;
        private string saveOrgPath;
        private int captureCount;
        private bool needClone;
        private bool cloneDone;
        private Thread fakeComPortThread;
        private bool useFakeCom;
        private List<int> spinAngleList;
        private List<string> resList;
        private bool isCamNeedRestart;
        private bool isSettingResolution;
        foucsCtrl fc = new foucsCtrl();
        ToolTip tt = new ToolTip();

        private void changeFocus(object sender, int e) {
            this.capture.Set(VideoCaptureProperties.Focus, e);
        }

        public Form1() {
            InitializeComponent();
        }

        private void updateCameraNo() {
            相機編號ToolStripMenuItem.Text = "相機編號：" + cameraNo;
        }

        private void updateShootCount() {
            拍攝樣本數ToolStripMenuItem.Text = "拍攝樣本數：" + shootCount;
        }

        private void updateSpinAngle() {
            旋轉角度ToolStripMenuItem.Text = "旋轉角度：" + spinAngleList[spinAngle];
        }

        private void updateRes() {
            解析度ToolStripMenuItem1.Text = "解析度：" + resList[resIndex];
            String[] sett = resList[resIndex].Split('x');
            camWidth = int.Parse(sett[0]);
            camHeigh = int.Parse(sett[1]);
            updateCamResolution();
        }

        private void updateCamResolution() {
            // capture.Set(VideoCaptureProperties.FrameWidth, camWidth);
            // capture.Set(VideoCaptureProperties.FrameHeight, camHeigh);
            capture.FrameWidth = camWidth;
            capture.FrameHeight = camHeigh;
        }


        private void Form1_Load(object sender, EventArgs e) {
            this.Text = "自動取樣程式";
            useComport = "";
            capture = new VideoCapture();
            resList = new List<string>();
            resList.Add("800x600");
            resList.Add("1024x768");
            resList.Add("1400x1050");
            resList.Add("1600x1200");
            resList.Add("2048x1536");
            resList.Add("3200x2400");
            resIndex = 0;
            camWidth = 1024;
            camHeigh = 768;
            spinAngleList = new List<int>() {3, 6, 12};
            cameraNo = 0;
            searchLastCam();
            shootCount = 30;
            spinAngle = 0;
            // spinAngle = 2;
            updateCameraNo();
            updateSpinAngle();
            updateShootCount();
            updateFileBotom(Directory.GetCurrentDirectory());
            updateRes();
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorkerRestart;
            backgroundWorker1.RunWorkerAsync();
            label1.Text = "開啟中";
            isStartCapture = false;
            captureCount = 0;
            label5.Text = "0/30";
            needClone = false;
            cloneDone = false;
            fakeComPortThread = new Thread(() => Thread.Sleep(1000));
            useFakeCom = false;
            FormClosing += mainFormClose;
            fc.changeFocus += this.changeFocus;
            medNameTextBox.KeyPress += textBox_KeyPress;
            // 旋轉角度ToolStripMenuItem.Visible = false;
            isCamNeedRestart = false;
            isSettingResolution = false;
        }

        private void searchLastCam() {
            for (int i = 0; i < 254; i++) {
                if (!capture.Open(i, VideoCaptureAPIs.ANY)) {
                    if (i != 0) {
                        cameraNo = --i;
                        updateCameraNo();
                    }

                    break;
                }
            }
        }

        private void 相機編號ToolStripMenuItem_Click(object sender, EventArgs e) {
            isCamNeedRestart = false;
            backgroundWorker1.CancelAsync();
            capture.Dispose();
            pictureBox1.Image = null;
            pictureBox1.Image?.Dispose();
            capture = new VideoCapture();
            // updateCamResolution();
            var sc = new SelectNumForm();
            sc.SelectLabel = "相機編號：";
            sc.SelectNum = cameraNo;
            if (sc.ShowDialog() == DialogResult.OK) {
                cameraNo = sc.SelectNum;
                updateCameraNo();
            }

            backgroundWorker1.RunWorkerAsync();
            sc.Close();
        }

        private void 拍攝樣本數ToolStripMenuItem_Click(object sender, EventArgs e) {
            var sc = new SelectNumForm();
            sc.SelectLabel = "拍攝樣本數：";
            sc.SelectNum = shootCount;
            if (sc.ShowDialog() == DialogResult.OK) {
                shootCount = sc.SelectNum;
                label5.Text = "0/" + shootCount;
                updateShootCount();
            }

            sc.Close();
        }

        private void 旋轉角度ToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectNumCombo snc = new SelectNumCombo();
            snc.labelText = "旋轉角度：";
            foreach (var v in spinAngleList) {
                snc.addComboItem = v + "度";
            }

            // snc.Width /= 2;
            if (snc.ShowDialog() == DialogResult.OK) {
                spinAngle = snc.getSelectIndex;
                updateSpinAngle();
            }

            snc.Close();
        }

        private void backgroundWorkerRestart(object sender, RunWorkerCompletedEventArgs e) {
            if (isCamNeedRestart) {
                isCamNeedRestart = false;
                capture.Dispose();
                Thread.Sleep(1000);
                backgroundWorker1.RunWorkerAsync();
                isStartCapture = false;
                button2.InvokeFunc((() => button2.Text = "開始"));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            var bgWorker = (BackgroundWorker) sender;
            if (capture.IsDisposed) {
                capture = new VideoCapture();
            }

            if (!capture.IsOpened()) {
                label1.InvokeFunc((() => label1.Text = "啟動相機"));
                label1.InvokeFunc((() => label1.ForeColor = Color.Black));
                if (!capture.Open(cameraNo, VideoCaptureAPIs.DSHOW)) {
                    label1.InvokeFunc((() => label1.Text = "開啟相機失敗"));
                    label1.InvokeFunc((() => label1.ForeColor = Color.Red));
                    pictureBox1.Image = null;
                    isCamNeedRestart = true;
                    Thread.Sleep(1000);
                    backgroundWorker1.CancelAsync();
                    return;
                }

                updateCamResolution();
                capture.Set(VideoCaptureProperties.AutoFocus, 1);
                label1.InvokeFunc((() => label1.Text = "開啟相機成功"));
            }

            while (!bgWorker.CancellationPending) {
                try {
                    using (var frameMat = capture.RetrieveMat()) {
                        if (frameMat.Empty()) {
                            isCamNeedRestart = true;
                            label1.InvokeFunc((() => label1.Text = "重新連接相機"));
                            backgroundWorker1.CancelAsync();
                        }

                        if (needClone) {
                            currentFrame = frameMat.Clone();
                            needClone = false;
                            cloneDone = true;
                        }

                        var frameBitmap = frameMat.ToBitmap();
                        bgWorker.ReportProgress(0, frameBitmap);
                    }
                } catch {
                    // ignore
                }


                Thread.Sleep(50);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var frameBitmap = (Bitmap) e.UserState;
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = frameBitmap;
        }

        // private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e){
        //     String str = toolStripComboBox1.SelectedItem.ToString();
        //     String[] sett = str.Split('x');
        //     camWidth = int.Parse(sett[0]);
        //     camHeigh = int.Parse(sett[1]);
        //     updateCamResolution();
        // }

        private void updateFileBotom(String path) {
            saveDir = path;
            button1.Text = saveDir;
            tt.SetToolTip(button1, saveDir);
        }

        private void button1_Click(object sender, EventArgs e) {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                updateFileBotom(dialog.FileName);
            }

            dialog.Dispose();
        }

        private void fakeComPortDo(int time) {
            while (true) {
                if (isStartCapture) {
                    savePhoto();
                }

                Thread.Sleep(time);
            }
        }

        private void cOMPORTToolStripMenuItem_Click(object sender, EventArgs e) {
            if (serialPort1.IsOpen) {
                serialPort1.Dispose();
            }

            useFakeCom = false;
            if (fakeComPortThread.IsAlive) {
                fakeComPortThread.Abort();
            }

            serialPort1 = new SerialPort();
            serialPort1.DataReceived += onRecvData;
            SelectNumCombo snc = new SelectNumCombo();
            snc.labelText = "選擇機器：";
            var cpList = comport.FindComPorts();
            if (!IsRelease) {
                cpList.Add(new comport.PortInfo("Fake0.5", "FakeComPort0.5s"));
                cpList.Add(new comport.PortInfo("Fake1", "FakeComPort1s"));
            }

            foreach (var portInfo in cpList) {
                snc.addComboItem = portInfo.Description; // + "(" + portInfo.Name + ")";
            }

            if (snc.ShowDialog() == DialogResult.OK && snc.getSelectIndex >= 0) {
                useComport = cpList[snc.getSelectIndex].Name;
                if (useComport == "Fake0.5") {
                    fakeComPortThread = new Thread(() => fakeComPortDo(500));
                    useFakeCom = true;
                }

                if (useComport == "Fake1") {
                    fakeComPortThread = new Thread(() => fakeComPortDo(1000));
                    useFakeCom = true;
                }


                try {
                    if (!useFakeCom) {
                        serialPort1.BaudRate = 115200;
                        serialPort1.PortName = useComport;
                        serialPort1.Open();
                    }

                    label1.InvokeFunc(() => label1.Text = "Comport 開啟成功");
                    label1.InvokeFunc(() => label1.ForeColor = Color.Black);
                    cOMPORTToolStripMenuItem.Text = "ComPort：" + useComport;
                } catch {
                    label1.InvokeFunc(() => label1.Text = "Comport 開啟失敗");
                    label1.InvokeFunc(() => label1.ForeColor = Color.Red);
                }
            }

            snc.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            startCapture();
        }

        private void startCapture() {
            if (isStartCapture) {
                isStartCapture = false;
                button2.Text = "開始";
                return;
            }

            if (!serialPort1.IsOpen && !useFakeCom) {
                if (useComport == "") {
                    MessageBox.Show("ComPort連結失敗");
                    return;
                }

                try {
                    if (!useFakeCom) {
                        if (serialPort1 == null) {
                            serialPort1 = new SerialPort();
                            serialPort1.DataReceived += onRecvData;
                        }

                        serialPort1.BaudRate = 115200;
                        serialPort1.PortName = useComport;
                        serialPort1.Open();
                        Thread.Sleep(500);
                    }

                    label1.InvokeFunc(() => label1.Text = "Comport 開啟成功");
                    label1.InvokeFunc(() => label1.ForeColor = Color.Black);
                    cOMPORTToolStripMenuItem.Text = "ComPort：" + useComport;
                } catch {
                    label1.InvokeFunc(() => label1.Text = "Comport 開啟失敗");
                    label1.InvokeFunc(() => label1.ForeColor = Color.Red);
                    isStartCapture = false;
                    button2.InvokeFunc((() => button2.Text = "開始"));
                }
            }

            if (!capture.IsOpened()) {
                backgroundWorker1.CancelAsync();
                Thread.Sleep(200);
                return;
            }

            if (medNameTextBox.Text.Length <= 0) {
                MessageBox.Show("藥名不可空白");
                return;
            }

            savePath = Path.Combine(saveDir, medNameTextBox.Text);
            saveOrgPath = Path.Combine(savePath, "Orgin");
            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }

            if (!Directory.Exists(saveOrgPath)) {
                Directory.CreateDirectory(saveOrgPath);
            }

            if (!useFakeCom) {
                try {
                    serialPort1.Write("?S=" + spinAngle + "#");
                } catch (Exception e) {
                    label1.InvokeFunc((() => {
                        label1.Text = "COMPORT連結錯誤";
                        label1.ForeColor = Color.Red;
                        serialPort1.Dispose();
                        Thread.Sleep(300);
                        isStartCapture = false;
                        button2.InvokeFunc((() => button2.Text = "開始"));
                    }));
                }
            } else {
                if (fakeComPortThread.IsAlive) {
                    fakeComPortThread.Abort();
                    if (useComport == "Fake0.5") {
                        fakeComPortThread = new Thread((() => fakeComPortDo(500)));
                    }

                    if (useComport == "Fake1") {
                        fakeComPortThread = new Thread((() => fakeComPortDo(1000)));
                    }
                }

                fakeComPortThread.Start();
            }

            if (captureCount >= shootCount) {
                captureCount = 0;
            }

            button3.Enabled = true;
            isStartCapture = true;
            button2.Text = "暫停";
        }

        private void onRecvData(object sender, SerialDataReceivedEventArgs e) {
            string str = "";
            while (serialPort1.BytesToRead > 0) {
                int recvValue = serialPort1.ReadByte();
                switch (recvValue) {
                    case '?':
                        str = "";
                        break;
                    case '#':
                        arduinoComm(str);
                        break;
                    default:
                        str += ((char) recvValue).ToString();
                        break;
                }
            }
        }

        private void arduinoComm(string str) {
            switch (str) {
                case "END":
                    savePhoto();
                    break;
                case "START":
                    startCapture();
                    break;
            }
        }

        private void savePhoto() {
            if (!isStartCapture) {
                return;
            }

            captureCount++;
            if (captureCount >= shootCount) {
                isStartCapture = false;
                button2.InvokeFunc((() => {
                    button2.Text = "開始";
                    button3.Enabled = false;
                }));
            }

            needClone = true;
            while (!cloneDone) { }

            Mat resizeMat = currentFrame.Resize(new OpenCvSharp.Size(640, 480));
            resizeMat.SaveImage(Path.Combine(savePath,
                medNameTextBox.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_") + captureCount + ".jpg"));
            currentFrame.SaveImage(Path.Combine(saveOrgPath,
                medNameTextBox.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_") + captureCount + ".png"));
            label5.InvokeFunc(() => label5.Text = captureCount + "/" + shootCount);
            cloneDone = false;
            if (!useFakeCom) {
                try {
                    serialPort1.Write("?S=" + spinAngle + "#");
                } catch (Exception e) {
                    label1.InvokeFunc((() => {
                        label1.Text = "COMPORT連結錯誤";
                        label1.ForeColor = Color.Red;
                        serialPort1.Dispose();
                        Thread.Sleep(300);
                        isStartCapture = false;
                        button2.InvokeFunc((() => button2.Text = "開始"));
                    }));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            isStartCapture = false;
            button2.Text = "開始";
            button3.Enabled = false;
            captureCount = 0;
            label5.Text = "0/" + shootCount;
        }

        private void mainFormClose(object sender, CancelEventArgs e) {
            label1.Text = "關閉中";
            fc.Close();
            fc.Dispose();
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            capture.Dispose();
            fakeComPortThread.Abort();
        }

        private void 焦距ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fc.ShowDialog() == DialogResult.Retry) {
                capture.Set(VideoCaptureProperties.AutoFocus, 1);
            }
        }

        private void 開啟儲存資料夾ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Directory.Exists(saveDir)) {
                ProcessStartInfo startInfo = new ProcessStartInfo {Arguments = saveDir, FileName = "explorer.exe"};

                Process.Start(startInfo);
            }
        }

        private void 解析度ToolStripMenuItem1_Click_1(object sender, EventArgs e) {
            SelectNumCombo snc = new SelectNumCombo();
            snc.labelText = "解析度：";
            foreach (var v in resList) {
                snc.addComboItem = v;
            }

            // snc.Width /= 2;
            if (snc.ShowDialog() == DialogResult.OK) {
                resIndex = snc.getSelectIndex;
                updateRes();
            }

            snc.Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] {e.KeyChar}) > 1) {
                e.Handled = true;
            }
        }
    }


    public static class Extension {
        //非同步委派更新UI
        public static void InvokeFunc(this Control control, MethodInvoker action) {
            if (control != null && control.InvokeRequired) //在非當前執行緒內 使用委派
            {
                control.Invoke(action);
            } else {
                if (action != null) action();
            }
        }
    }
}