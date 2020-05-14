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
    public partial class Form1 : Form
    {
        public Form2 form2;
        public CircleController circleController;

        public Form1()
        {
            InitializeComponent();
            circleController = new CircleController(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2(this);
            form2.Location = new Point(Location.X + 250, Location.Y);
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            circleController.tickEnabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form2.Close();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            circleController.tickEnabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            circleController.circles.Clear();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                form2.WindowState = FormWindowState.Minimized;
                button3_Click(sender, e);
            }

            if (WindowState == FormWindowState.Normal)
            {
                form2.WindowState = FormWindowState.Normal;
                button1_Click(sender, e);
            }
        }
    }
}
