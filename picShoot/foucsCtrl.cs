using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace picShoot {
    public partial class foucsCtrl : Form {
        public event EventHandler<int> changeFocus; 
        public foucsCtrl() {
            InitializeComponent();
        }

        private void foucsCtrl_Load(object sender, EventArgs e) {
            textBox1.Text = hScrollBar1.Value.ToString();
            button2.DialogResult = DialogResult.Retry;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            int num;
            if (int.TryParse(textBox1.Text, out num)) {
                if (num > 255) {
                    num = 255;
                }

                if (num < 0) {
                    num = 0;
                }

                hScrollBar1.Value = num;
                if (changeFocus != null) {
                    changeFocus.Invoke(this,hScrollBar1.Value);
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e) {
            if (changeFocus != null) {
                changeFocus.Invoke(this,hScrollBar1.Value);
            }

            textBox1.Text = hScrollBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}