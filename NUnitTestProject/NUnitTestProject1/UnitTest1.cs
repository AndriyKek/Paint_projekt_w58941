using System;
using NUnit.Framework;


namespace ImageEditor
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OpeningColorPickerTest()
        {
            void TestNewForm()
            {
                Form1 f1 = new Form1();
                f1.Show();

                ExpectModal("ColorPicker", "CloseDialog");

                // Check if Button has the right Text
                ButtonTester bt = new ButtonTester("btMore", f1);
                Assert.AreEqual("More...", bt.Text);

                bt.Click();
            }
            void CloseDialog()
            {
                ButtonTester btClose = new ButtonTester("btMore");
                btClose.Click();
            }
        }

        private void ExpectModal(string v1, string v2)
        {
            throw new NotImplementedException();
        }


        [Test]
        public void OpenButtonTest()
        {
            void TestNewForm()
            {
                Form1 form1 = new Form1();
                form1.Show();

                ExpectModal("Form1", "OpenDialog");

                // Check if Button has the right Text
                ButtonTester bt = new ButtonTester("btOpen", form1);
                Assert.AreEqual("Open", bt.Text);

                bt.Click();
            }

        }
        [Test]
        public void SaveButtonTest()
        {
            void TestNewForm()
            {
                Form1 form1 = new Form1();
                form1.Show();

                ExpectModal("Form1", "SaveDialog");

                
                ButtonTester bt = new ButtonTester("btSave", form1);
                Assert.AreEqual("Save", bt.Text);

                bt.Click();
            }
        }
    }
  
}
