using System;
using System.Windows.Forms;

namespace picShoot
{
    public partial class SelectNumCombo : Form
    {
        public string labelText {
            get => label1.Text;
            set => label1.Text = value;
        }

        public string addComboItem {
            set => comboBox1.Items.Add(value);
        }

        public int getSelectIndex {
            get => comboBox1.SelectedIndex;
        }


        public SelectNumCombo()
        {
            InitializeComponent();
        }

        private void SelectNumCombo_Load(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) { }
    }
}
