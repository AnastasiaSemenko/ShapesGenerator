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
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 27);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(342, 29);
            progressBar1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(260, 91);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(12, 91);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(94, 29);
            buttonStop.TabIndex = 2;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 132);
            ControlBox = false;
            Controls.Add(buttonStop);
            Controls.Add(buttonCancel);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ProgressForm";
            Text = "ProgressForm";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Button buttonCancel;
        private Button buttonStop;
    }
}