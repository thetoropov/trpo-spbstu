using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pz7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point pos; //start position
        Point delta; //speed

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePositionButton();
        }

        private void ChangePositionButton()
        {
            Point newPos;
            newPos = MousePosition;
            CalcDelta(newPos);

            if(button1.Location.X - delta.X < 5)
            {
                button1.Location = new Point(Form1.ActiveForm.Width - button1.Width - 20, button1.Location.Y);
            }
            else if (button1.Location.X - delta.X > Form1.ActiveForm.Width - button1.Width - 20)
            {
                button1.Location = new Point(5, button1.Location.Y);
            }
            else if (button1.Location.Y - delta.Y < 5)
            {
                button1.Location = new Point(button1.Location.X, Form1.ActiveForm.Height - button1.Height - 35);
            }
            else if (button1.Location.Y - delta.Y > Form1.ActiveForm.Height - button1.Height - 35)
            {
                button1.Location = new Point(button1.Location.X, 5);
            }
            else
            {
                button1.Location = new Point(button1.Location.X - delta.X, button1.Location.Y - delta.Y);
            }
        }
        
        private void CalcDelta(Point newPos)
        {
            delta.X = pos.X - newPos.X;
            delta.Y = pos.Y - newPos.Y;
            pos = newPos;
        }


        private void RunningForm_ResizeEnd(object sender, EventArgs e)
        {
            if (button1.Location.X < 5)
            {
                button1.Location = new Point(5, button1.Location.Y);
            }

            if (button1.Location.X > Form1.ActiveForm.Width - button1.Width - 20)
            {
                button1.Location = new Point(Form1.ActiveForm.Width - button1.Width - 20, button1.Location.Y);
            }

            if (button1.Location.Y < 5)
            {
                button1.Location = new Point(button1.Location.X, 5);
            }

            if (button1.Location.Y > Form1.ActiveForm.Height - button1.Height - 35)
            {
                button1.Location = new Point(button1.Location.X, Form1.ActiveForm.Height - button1.Height - 35);
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePositionButton();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!");
            Close();
        }
    }
}
