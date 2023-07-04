namespace ShapeGenerator
{
    public partial class ProgressForm : Form
    {
        public bool Cancelled { get; private set; }
        public bool Stopped { get; private set; }

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void CloseForm()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(CloseForm));
            else
                Close();
        }

        public void SetMaximumProgress(int maxValue)
        {
            progressBar1.Maximum = maxValue;
        }

        public void UpdateProgress(int value)
        {
            progressBar1.Value = value;
            progressBar1.Refresh();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stopped = true;
        }
    }
}