using NetEti.ApplicationEnvironment;

namespace NetEti.DemoApplications
{
    /// <summary>
    /// Demo
    /// </summary>
    public partial class Form1 : Form
    {
        private CommandLineAccess? _CommandLineAccess;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._CommandLineAccess = new CommandLineAccess();
            this.listBox1.Items.Add(String.Format("{0}: {1}", "blubber", this._CommandLineAccess.GetStringValue("blubber", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Noppes", this._CommandLineAccess.GetStringValue("Noppes", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 0", this._CommandLineAccess.GetStringValue("0", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 1", this._CommandLineAccess.GetStringValue("1", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 2", this._CommandLineAccess.GetStringValue("2", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 3", this._CommandLineAccess.GetStringValue("3", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 4", this._CommandLineAccess.GetStringValue("4", "---")));
            this.listBox1.Items.Add(String.Format("{0}: {1}", "Param 5", this._CommandLineAccess.GetStringValue("Job", "---")));
        }
    }
}
