internal class FormTester
{
    private string form1;

    public FormTester(string form1)
    {
        this.form1 = form1;
    }

    public ColorPicker TheObject { get; internal set; }
}