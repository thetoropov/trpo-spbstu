using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pz9
{
    public partial class Form2 : Form
    {
        bool dr = false;
        Form1 form1;

        public Form2(Form1 _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (dr)
            {
                form1.circleController.Draw(e);
            }
            else
            {
                dr = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (form1.numericUpDownMinLife.Value > form1.numericUpDownMaxLife.Value)
            {
                form1.numericUpDownMinLife.Value = form1.numericUpDownMaxLife.Value;
            }

            form1.circleController.Tick();

            Invalidate();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                form1.WindowState = FormWindowState.Minimized;
            }
            if (WindowState == FormWindowState.Normal)
            {
                form1.WindowState = FormWindowState.Normal;
            }
        }
    }
}
