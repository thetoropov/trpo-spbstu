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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("Library.xml");
            string input = textBox1.Text;
            IEnumerable<XElement> books = doc.Root.Descendants("Account");

            if (input == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Заполните форму",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        books = doc.Root.Descendants("Account").Where(
                            t => t.Element("IdAccount").Value == input);
                        books.Remove();
                        break;
                    case 1:
                        books = doc.Root.Descendants("Account").Where(
                            t => t.Element("LastName").Value == input);
                        books.Remove();
                        break;
                    case 2:
                        books = doc.Root.Descendants("Account").Where(
                            t => t.Element("IdCode").Value == input);
                        books.Remove();
                        break;

                }
                doc.Save("Library.xml");

                Close();
            }
        }
    }
}
