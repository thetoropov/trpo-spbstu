using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace pz8
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("Library.xml");
            try
            {
                DateTime.Parse(textBoxDate.Text);
                if (DateTime.Parse(textBoxDate.Text) > DateTime.Today) { throw new Exception(); };
                if (!textBoxLastName.Text.All(c => char.IsLetter(c))) { throw new Exception(); };

                XElement Book = new XElement("Account",
                        new XElement("IdAccount", Int32.Parse(textBoxIdAccount.Text)),
                        new XElement("IdCode", Int32.Parse(textBoxIdCode.Text)),
                        new XElement("LastName", textBoxLastName.Text),
                        new XElement("Amount", Int32.Parse(textBoxAmount.Text)),
                        new XElement("Data", textBoxDate.Text),
                        new XElement("Percent", Int32.Parse(textBoxPercent.Text)));
                doc.Root.Add(Book);
                doc.Save("Library.xml");

                Close();
            }
            catch
            {
                MessageBox.Show(
                    "Введены некорректные данные",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
