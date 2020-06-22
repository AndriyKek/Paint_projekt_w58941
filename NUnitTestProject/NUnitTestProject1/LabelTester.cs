namespace ImageEditor
{
    internal class LabelTester
    {
        private string v;

        public LabelTester(string v)
        {
            this.v = v;
        }

        public object Text { get; internal set; }
    }
}