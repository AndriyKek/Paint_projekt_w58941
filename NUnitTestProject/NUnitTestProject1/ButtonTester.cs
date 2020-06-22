using System;

namespace ImageEditor
{
    internal class ButtonTester
    {
        private string v;
        private Form1 f1;

        public ButtonTester(string v)
        {
            this.v = v;
        }

        public ButtonTester(string v, string v1)
        {
            this.v = v;
        }

        public ButtonTester(string v, Form1 f1)
        {
            this.v = v;
            this.f1 = f1;
        }

        public double Text { get; internal set; }

        internal void Click()
        {
            throw new NotImplementedException();
        }
    }
}