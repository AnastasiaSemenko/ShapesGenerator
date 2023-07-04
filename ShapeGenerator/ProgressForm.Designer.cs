namespace ShapeGenerator
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            buttonCancel = new Button();
            buttonStop = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar1
            // 
            tableLayoutPanel1.SetColumnSpan(progressBar1, 2);
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(9, 8);
            progressBar1.Margin = new Padding(9, 8, 9, 8);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(302, 16);
            progressBar1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.ForeColor = SystemColors.ActiveCaptionText;
            buttonCancel.Location = new Point(221, 47);
            buttonCancel.Margin = new Padding(61, 15, 9, 8);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(90, 22);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonStop
            // 
            buttonStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonStop.Location = new Point(9, 47);
            buttonStop.Margin = new Padding(9, 15, 61, 8);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(90, 22);
            buttonStop.TabIndex = 2;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonStop, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 41.7475739F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 58.2524261F));
            tableLayoutPanel1.Size = new Size(320, 77);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 77);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProgressForm";
            Text = "ProgressForm";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Button buttonStop;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonCancel;
    }
}