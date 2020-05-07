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
    public partial class Form1 : Form
    {
        string fileName = "Library.xml";

        public Form1()
        {
            InitializeComponent();
        }

        public void CreateXML()
        {
            int idCard = 0;
            int idCode = 0;

            XDocument doc = new XDocument(
                new XElement("BankCollection",
                    new XElement("Account",
                        new XElement("IdAccount", idCard++),
                        new XElement("IdCode", idCode++),
                        new XElement("LastName", "Заплатин"),
                        new XElement("Amount", 100),
                        new XElement("Data", "19.03.2020"),
                        new XElement("Percent", 30)),
                    new XElement("Account",
                        new XElement("IdAccount", idCard++),
                        new XElement("IdCode", idCode++),
                        new XElement("LastName", "Канева"),
                        new XElement("Amount", 200),
                        new XElement("Data", "12.03.2020"),
                        new XElement("Percent", 40)),
                    new XElement("Account",
                        new XElement("IdAccount", idCard++),
                        new XElement("IdCode", idCode++),
                        new XElement("LastName", "Сухомлинов"),
                        new XElement("Amount", 300),
                        new XElement("Data", "10.03.2020"),
                        new XElement("Percent", 50))));
            doc.Save(fileName);
        }

       public bool CheckValue(string IdAccount, string IdCode, string Amount,
            string Percent, string Data, string LastName)
        {
            try
            {
                Int32.Parse(IdAccount);
                Int32.Parse(IdCode);
                Int32.Parse(Amount);
                Int32.Parse(Percent);
                DateTime.Parse(Data);
                if (DateTime.Parse(Data) > DateTime.Today) { throw new Exception(); };
                
                if (Int32.Parse(Percent) < 0) { throw new Exception(); };
                if (Int32.Parse(Amount) < 0) { throw new Exception(); };

                if (String.IsNullOrEmpty(IdAccount)
                    || String.IsNullOrEmpty(Data)
                    || String.IsNullOrEmpty(Amount)
                    || String.IsNullOrEmpty(Percent)
                    || String.IsNullOrEmpty(Data)
                    || String.IsNullOrEmpty(LastName)) { throw new Exception(); };
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateXML();
            try
            {
                loadFromXML(fileName);
            }
            catch
            {
                MessageBox.Show(
                   "Невозможно считать данные",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                Close();
            }
        }

        public void loadFromXML(string xmlPath)
        {
            XDocument doc;

            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch
            {
                throw new ArgumentException();
            }

            foreach (XElement el in doc.Root.Elements())
            {
                if (!CheckValue(
                    el.Element("IdAccount").Value,
                    el.Element("IdCode").Value,
                    el.Element("Amount").Value,
                    el.Element("Percent").Value,
                    el.Element("Data").Value,
                    el.Element("LastName").Value))
                {
                    throw new Exception();
                }
                var row = new string[] {el.Element("IdAccount").Value, el.Element("IdCode").Value, el.Element("LastName").Value,
                        el.Element("Amount").Value, el.Element("Data").Value, el.Element("Percent").Value};
                var lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            XDocument doc = XDocument.Load(fileName);
            IEnumerable<XElement> books = doc.Root.Descendants("Account");
            string input = textBox1.Text;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    books = doc.Root.Descendants("Account").Where(
                        book => book.Element("IdAccount").Value == input).ToList();
                    break;
                case 1:
                    books = doc.Root.Descendants("Account").Where(
                        book => book.Element("Data").Value == input).ToList();
                    break;
                case 2:
                    books = doc.Root.Descendants("Account").Where(
                        book => book.Element("LastName").Value == input).ToList();
                    break;

            }
            foreach (XElement el in books)
            {
                var row = new string[] {el.Element("IdAccount").Value, el.Element("IdCode").Value, el.Element("LastName").Value,
                el.Element("Amount").Value, el.Element("Data").Value, el.Element("Percent").Value};
                var lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            XDocument doc = XDocument.Load(fileName);
            IEnumerable<XElement> books = doc.Root.Descendants("Account").OrderBy(
                book => book.Element("IdAccount").Value);
            textBox1.Clear();
            foreach (XElement el in books)
            {
                var row = new string[] {el.Element("IdAccount").Value, el.Element("IdCode").Value, el.Element("LastName").Value,
                el.Element("Amount").Value, el.Element("Data").Value, el.Element("Percent").Value};
                var lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.ShowDialog();
            button_clear.PerformClick();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DeleteForm form = new DeleteForm();
            form.ShowDialog();
            button_clear.PerformClick();
        }


    }
}
