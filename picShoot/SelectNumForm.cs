using System;
using System.Windows.Forms;

namespace picShoot
{
    public partial class SelectNumForm : Form
    {
        public int SelectNum {
            get => (int)(numericUpDown1.Value);
            set => numericUpDown1.Value = value;
        }

        public string SelectLabel {
            set => label1.Text = value;
        }

        public SelectNumForm()
        {
            InitializeComponent();
        }

        private void SelectCam_Load(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}