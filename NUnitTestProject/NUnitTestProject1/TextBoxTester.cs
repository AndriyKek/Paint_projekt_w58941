using System;

namespace ImageEditor
{
    internal class TextBoxTester
    {
        private string v;

        public TextBoxTester(string v)
        {
            this.v = v;
        }

        public double Text { get; internal set; }

        internal void Enter(string v)
        {
            throw new NotImplementedException();
        }
    }
}