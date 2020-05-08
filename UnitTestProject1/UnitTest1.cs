using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.IO;
using pz8;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void checkForIncorrectXMLFileInput()
        {
            Form1 form = new Form1();
            string fileName = "Test.xml";

            XDocument doc = new XDocument(
                new XElement("BankCollection",
                    new XElement("Account",
                        new XElement("Data", "19.03.99999"),
                        new XElement("asdas", 30),
                        new XElement("asd", "Виктор Пелевин"),
                        new XElement("asd", "S.N.U.F.F."),
                        new XElement("asda", 2011),
                        new XElement("asd", "Азбука-Аттикус"),
                        new XElement("asd", 450)),
                    new XElement("NotAccount",
                        new XElement("asdas", 78),
                        new XElement("LastName", "Канева"),
                        new XElement("DataOfIssue", "20.04.2020"),
                        new XElement("DataReturn", 30),
                        new XElement("asd", "Стендаль"),
                        new XElement("asd", "Искусство"),
                        new XElement("Prasdice", 250))));

            doc.Save(fileName);
            form.loadFromXML(fileName);
        }

        [TestMethod]
        public void checkForCorrectXMLFileInput()
        {
            Form1 form = new Form1();
            string fileName = "Test.xml";

            XDocument doc = new XDocument(
                new XElement("BankCollection",
                    new XElement("Account",
                        new XElement("IdAccount", 11),
                        new XElement("IdCode", 12),
                        new XElement("LastName", "Канева"),
                        new XElement("Amount", 100),
                        new XElement("Data", "19.03.2020"),
                        new XElement("Percent", 30))));

            doc.Save(fileName);
            form.loadFromXML(fileName);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void checkForEmptyPathXMLFileInput()
        {
            Form1 form = new Form1();

            form.loadFromXML(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void checkForEmptyXMLFile()
        {
            Form1 form = new Form1();
            string fileName = "Test.xml";

            XDocument doc = new XDocument(new XElement("Account"));
            doc.Save(fileName);

            File.WriteAllText(fileName, String.Empty);
            form.loadFromXML(fileName);
        }

        [TestMethod]
        public void checkValueForEmptyInput()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("", "", "", "", "", "");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void checkValueForCorrectInput()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("134", "3000", "123", "123", "19.03.2020", "Пелевин");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void checkValueForIntParsing()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("f41", "маша", "19.03.2020", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "маша", "19.03.2020", "335f0  fdf", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("134", "3000", "123", "123", "19.03.2020", "Пелевин");
            Assert.IsTrue(result);

            result = form.CheckValue("12331", "123", "21321", "12312", "12.11.2010", "Пелевин");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void checkValueForDateParsing()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("1", "маша", "19.03.9999899", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "маша", "-19.03.1834", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "маша", "34.23.tr433", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "30", "2011", "450", "19.03.2020", "маша");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void checkValueForNullInput()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("1", "маша", "19.03.9999", "30", "Виктор Пелевин", null);
            Assert.IsFalse(result);

            result = form.CheckValue("1", null, "19.03.1834", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue(null, null, null, null, null, null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void checkValueForInputWithSpecSymbols()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("*&(#$", "*)$#", ")(*$#", "&*(#", "()#", "#(*&");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void checkValueForCorrectYearOfPublishing()
        {
            Form1 form = new Form1();

            bool result = form.CheckValue("1", "маша", "19.03.9999", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "маша", "19.03.1834", "30", "Виктор Пелевин", "S.N.U.F.F.");
            Assert.IsFalse(result);

            result = form.CheckValue("1", "30", "2011", "450", "19.03.2020", "маша");
            Assert.IsTrue(result);
        }

    }
}
