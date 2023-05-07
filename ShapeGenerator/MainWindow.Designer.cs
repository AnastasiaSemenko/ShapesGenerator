namespace ShapeGenerator
{
    partial class MainWindow
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
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            listBoxShapesInfo = new ListBox();
            label1 = new Label();
            label2 = new Label();
            textBoxFrom = new TextBox();
            textBoxTo = new TextBox();
            buttonSquare = new Button();
            buttonTriangle = new Button();
            buttonRectangle = new Button();
            buttonHexagon = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(504, 155);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "gen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonGen_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(0, 190);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(714, 331);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(619, 155);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonClear_Click;
            // 
            // listBoxShapesInfo
            // 
            listBoxShapesInfo.Dock = DockStyle.Right;
            listBoxShapesInfo.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxShapesInfo.FormattingEnabled = true;
            listBoxShapesInfo.ItemHeight = 40;
            listBoxShapesInfo.Location = new Point(719, 0);
            listBoxShapesInfo.Name = "listBoxShapesInfo";
            listBoxShapesInfo.Size = new Size(279, 521);
            listBoxShapesInfo.Sorted = true;
            listBoxShapesInfo.TabIndex = 3;
            listBoxShapesInfo.DrawItem += listBoxShapesInfo_DrawItem;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 78);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 4;
            label1.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 78);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 5;
            label2.Text = "To";
            // 
            // textBoxFrom
            // 
            textBoxFrom.Location = new Point(68, 76);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.Size = new Size(55, 27);
            textBoxFrom.TabIndex = 6;
            textBoxFrom.Text = "10";
            textBoxFrom.KeyPress += textBoxFrom_KeyPress;
            // 
            // textBoxTo
            // 
            textBoxTo.Location = new Point(160, 76);
            textBoxTo.Name = "textBoxTo";
            textBoxTo.Size = new Size(63, 27);
            textBoxTo.TabIndex = 7;
            textBoxTo.Text = "100";
            textBoxTo.KeyPress += textBoxTo_KeyPress;
            // 
            // buttonSquare
            // 
            buttonSquare.Location = new Point(18, 21);
            buttonSquare.Name = "buttonSquare";
            buttonSquare.Size = new Size(94, 29);
            buttonSquare.TabIndex = 8;
            buttonSquare.Text = "square";
            buttonSquare.UseVisualStyleBackColor = true;
            buttonSquare.Click += buttonSquare_Click;
            // 
            // buttonTriangle
            // 
            buttonTriangle.Location = new Point(118, 21);
            buttonTriangle.Name = "buttonTriangle";
            buttonTriangle.Size = new Size(94, 29);
            buttonTriangle.TabIndex = 9;
            buttonTriangle.Text = "triangle";
            buttonTriangle.UseVisualStyleBackColor = true;
            buttonTriangle.Click += buttonTriangle_Click;
            // 
            // buttonRectangle
            // 
            buttonRectangle.Location = new Point(218, 21);
            buttonRectangle.Name = "buttonRectangle";
            buttonRectangle.Size = new Size(94, 29);
            buttonRectangle.TabIndex = 10;
            buttonRectangle.Text = "rectangle";
            buttonRectangle.UseVisualStyleBackColor = true;
            buttonRectangle.Click += buttonRectangle_Click;
            // 
            // buttonHexagon
            // 
            buttonHexagon.Location = new Point(318, 21);
            buttonHexagon.Name = "buttonHexagon";
            buttonHexagon.Size = new Size(94, 29);
            buttonHexagon.TabIndex = 11;
            buttonHexagon.Text = "hexagon";
            buttonHexagon.UseVisualStyleBackColor = true;
            buttonHexagon.Click += buttonHexagon_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 521);
            Controls.Add(buttonHexagon);
            Controls.Add(buttonRectangle);
            Controls.Add(buttonTriangle);
            Controls.Add(buttonSquare);
            Controls.Add(textBoxTo);
            Controls.Add(textBoxFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxShapesInfo);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "MainWindow";
            Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private ListBox listBoxShapesInfo;
        private Label label1;
        private Label label2;
        private TextBox textBoxFrom;
        private TextBox textBoxTo;
        private Button buttonSquare;
        private Button buttonTriangle;
        private Button buttonRectangle;
        private Button buttonHexagon;
    }
}