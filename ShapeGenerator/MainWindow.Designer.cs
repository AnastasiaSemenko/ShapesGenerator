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
            buttonGen = new Button();
            pictureBox = new PictureBox();
            buttonClear = new Button();
            listBoxShapesInfo = new ListBox();
            label1 = new Label();
            label2 = new Label();
            textBoxFrom = new TextBox();
            textBoxTo = new TextBox();
            buttonSquare = new Button();
            buttonTriangle = new Button();
            buttonRectangle = new Button();
            buttonHexagon = new Button();
            panel = new Panel();
            radioButtonIntersecting = new RadioButton();
            radioButtonNonIntersecting = new RadioButton();
            radioButtonEnclosure = new RadioButton();
            buttonSave = new Button();
            buttonLoad = new Button();
            labelMaxNestingLevel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // buttonGen
            // 
            buttonGen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonGen.Location = new Point(415, 154);
            buttonGen.Name = "buttonGen";
            buttonGen.Size = new Size(94, 30);
            buttonGen.TabIndex = 0;
            buttonGen.Text = "gen";
            buttonGen.UseVisualStyleBackColor = true;
            buttonGen.Click += ButtonGen_Click;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = Color.White;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(609, 328);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.SizeChanged += pictureBox_SizeChanged;
            pictureBox.Paint += pictureBox_Paint;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear.Location = new Point(515, 154);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 30);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // listBoxShapesInfo
            // 
            listBoxShapesInfo.Dock = DockStyle.Right;
            listBoxShapesInfo.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxShapesInfo.FormattingEnabled = true;
            listBoxShapesInfo.ItemHeight = 40;
            listBoxShapesInfo.Location = new Point(615, 0);
            listBoxShapesInfo.Name = "listBoxShapesInfo";
            listBoxShapesInfo.Size = new Size(392, 515);
            listBoxShapesInfo.TabIndex = 3;
            listBoxShapesInfo.DrawItem += ListBoxShapesInfo_DrawItem;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 94);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 4;
            label1.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 94);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 5;
            label2.Text = "To";
            // 
            // textBoxFrom
            // 
            textBoxFrom.Location = new Point(63, 87);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.Size = new Size(55, 27);
            textBoxFrom.TabIndex = 6;
            textBoxFrom.Text = "10";
            textBoxFrom.KeyPress += TextBoxFrom_KeyPress;
            // 
            // textBoxTo
            // 
            textBoxTo.Location = new Point(155, 87);
            textBoxTo.Name = "textBoxTo";
            textBoxTo.Size = new Size(63, 27);
            textBoxTo.TabIndex = 7;
            textBoxTo.Text = "100";
            textBoxTo.KeyPress += TextBoxTo_KeyPress;
            // 
            // buttonSquare
            // 
            buttonSquare.BackgroundImage = Properties.Resources.Square;
            buttonSquare.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSquare.Location = new Point(18, 12);
            buttonSquare.Name = "buttonSquare";
            buttonSquare.Size = new Size(60, 60);
            buttonSquare.TabIndex = 8;
            buttonSquare.UseVisualStyleBackColor = true;
            buttonSquare.Click += ButtonSquare_Click;
            // 
            // buttonTriangle
            // 
            buttonTriangle.BackgroundImage = Properties.Resources.Triangle;
            buttonTriangle.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTriangle.Location = new Point(97, 12);
            buttonTriangle.Name = "buttonTriangle";
            buttonTriangle.Size = new Size(60, 60);
            buttonTriangle.TabIndex = 9;
            buttonTriangle.UseVisualStyleBackColor = true;
            buttonTriangle.Click += ButtonTriangle_Click;
            // 
            // buttonRectangle
            // 
            buttonRectangle.BackgroundImage = Properties.Resources.Rectangle;
            buttonRectangle.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRectangle.Location = new Point(174, 12);
            buttonRectangle.Name = "buttonRectangle";
            buttonRectangle.Size = new Size(60, 60);
            buttonRectangle.TabIndex = 10;
            buttonRectangle.UseVisualStyleBackColor = true;
            buttonRectangle.Click += ButtonRectangle_Click;
            // 
            // buttonHexagon
            // 
            buttonHexagon.BackgroundImage = Properties.Resources.Hexagon;
            buttonHexagon.BackgroundImageLayout = ImageLayout.Stretch;
            buttonHexagon.Location = new Point(252, 12);
            buttonHexagon.Name = "buttonHexagon";
            buttonHexagon.Size = new Size(60, 60);
            buttonHexagon.TabIndex = 11;
            buttonHexagon.UseVisualStyleBackColor = true;
            buttonHexagon.Click += ButtonHexagon_Click;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.AutoScroll = true;
            panel.AutoScrollMargin = new Size(2, 2);
            panel.BackColor = SystemColors.Control;
            panel.Controls.Add(pictureBox);
            panel.Location = new Point(0, 190);
            panel.Name = "panel";
            panel.Size = new Size(610, 325);
            panel.TabIndex = 12;
            // 
            // radioButtonIntersecting
            // 
            radioButtonIntersecting.AutoSize = true;
            radioButtonIntersecting.Location = new Point(18, 119);
            radioButtonIntersecting.Name = "radioButtonIntersecting";
            radioButtonIntersecting.Size = new Size(107, 24);
            radioButtonIntersecting.TabIndex = 16;
            radioButtonIntersecting.TabStop = true;
            radioButtonIntersecting.Text = "Intersecting";
            radioButtonIntersecting.UseVisualStyleBackColor = true;
            radioButtonIntersecting.CheckedChanged += radioButtonIntersecting_CheckedChanged;
            // 
            // radioButtonNonIntersecting
            // 
            radioButtonNonIntersecting.AutoSize = true;
            radioButtonNonIntersecting.Location = new Point(18, 140);
            radioButtonNonIntersecting.Name = "radioButtonNonIntersecting";
            radioButtonNonIntersecting.Size = new Size(139, 24);
            radioButtonNonIntersecting.TabIndex = 17;
            radioButtonNonIntersecting.TabStop = true;
            radioButtonNonIntersecting.Text = "Non Intersecting";
            radioButtonNonIntersecting.UseVisualStyleBackColor = true;
            radioButtonNonIntersecting.CheckedChanged += radioButtonNonIntersecting_CheckedChanged;
            // 
            // radioButtonEnclosure
            // 
            radioButtonEnclosure.AutoSize = true;
            radioButtonEnclosure.Location = new Point(18, 161);
            radioButtonEnclosure.Name = "radioButtonEnclosure";
            radioButtonEnclosure.Size = new Size(93, 24);
            radioButtonEnclosure.TabIndex = 18;
            radioButtonEnclosure.TabStop = true;
            radioButtonEnclosure.Text = "Enclosure";
            radioButtonEnclosure.UseVisualStyleBackColor = true;
            radioButtonEnclosure.CheckedChanged += radioButtonEnclosure_CheckedChanged;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.Location = new Point(515, 21);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 19;
            buttonSave.Text = "save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoad.Location = new Point(515, 56);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(94, 29);
            buttonLoad.TabIndex = 20;
            buttonLoad.Text = "load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // labelMaxNestingLevel
            // 
            labelMaxNestingLevel.AutoSize = true;
            labelMaxNestingLevel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelMaxNestingLevel.ForeColor = Color.Teal;
            labelMaxNestingLevel.Location = new Point(174, 167);
            labelMaxNestingLevel.Name = "labelMaxNestingLevel";
            labelMaxNestingLevel.Size = new Size(143, 20);
            labelMaxNestingLevel.TabIndex = 21;
            labelMaxNestingLevel.Text = "Max nesting level - ";
            labelMaxNestingLevel.Visible = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 515);
            Controls.Add(labelMaxNestingLevel);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(radioButtonEnclosure);
            Controls.Add(radioButtonNonIntersecting);
            Controls.Add(radioButtonIntersecting);
            Controls.Add(buttonGen);
            Controls.Add(buttonHexagon);
            Controls.Add(buttonRectangle);
            Controls.Add(buttonTriangle);
            Controls.Add(buttonSquare);
            Controls.Add(textBoxTo);
            Controls.Add(textBoxFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxShapesInfo);
            Controls.Add(buttonClear);
            Controls.Add(panel);
            Name = "MainWindow";
            Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGen;
        private PictureBox pictureBox;
        private Button buttonClear;
        private ListBox listBoxShapesInfo;
        private Label label1;
        private Label label2;
        private TextBox textBoxFrom;
        private TextBox textBoxTo;
        private Button buttonSquare;
        private Button buttonTriangle;
        private Button buttonRectangle;
        private Button buttonHexagon;
        private Panel panel;
        private RadioButton radioButtonIntersecting;
        private RadioButton radioButtonNonIntersecting;
        private RadioButton radioButtonEnclosure;
        private Button buttonSave;
        private Button buttonLoad;
        private Label labelMaxNestingLevel;
    }
}