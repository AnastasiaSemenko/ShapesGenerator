using Enums.ShapeGenerator;
using Newtonsoft.Json;
using ShapeGenerator.Drawers;
using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public partial class MainWindow : Form
    {
        private DrawerController _drawerController;
        private Button _selectedButton;
        private Shape _selectedShape;
        private bool _positioning;

        public MainWindow()
        {
            InitializeComponent();
            MinimumSize = new Size(1050, 550);
            WindowState = FormWindowState.Maximized;
            _drawerController = new DrawerController(pictureBox);
            UpdateSelectedButton(buttonSquare);
            _drawerController.FigureShape = FigureShape.Square;
            radioButtonIntersecting.Checked = true;
            splitContainer1.Panel2MinSize = listBoxShapesInfo.Width;
            listBoxShapesInfo.ItemHeight = listBoxShapesInfo.Font.Height * 2;
        }

        private void ButtonGen_Click(object sender, EventArgs e)
        {

            _selectedShape = null;

            if (string.IsNullOrEmpty(textBoxFrom.Text) || string.IsNullOrEmpty(textBoxTo.Text))
            {
                ShowWarningMessageBox("The 'from' and 'to' fields must be filled in.");
                return;
            }

            var from = int.Parse(textBoxFrom.Text);
            var to = int.Parse(textBoxTo.Text);

            if (from > to)
            {
                ShowWarningMessageBox("The 'From' value cannot be greater than the 'Tо' value.");
                return;
            }

            buttonGen.Enabled = false;
            _drawerController.From = int.Parse(textBoxFrom.Text);
            _drawerController.To = int.Parse(textBoxTo.Text);
            var progressForm = new ProgressForm();
            progressForm.StartPosition = FormStartPosition.CenterParent;
            var processThread = new Thread(_drawerController.GenerateShapes);
            processThread.Start(progressForm);
            progressForm.ShowDialog();
            processThread.Join();
            pictureBox.Invalidate();
            UpdateListBoxShapesItems();

            if (_drawerController.DrawingOption == DrawingOption.Enclosure)
            {
                labelMaxNestingLevel.Text = "Max nesting level - " + _drawerController.GetMaxNestingLevel();
                labelMaxNestingLevel.Visible = true;
            }
            else
                labelMaxNestingLevel.Visible = false;

            buttonGen.Enabled = true;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            labelMaxNestingLevel.Visible = false;
            _selectedShape = null;
            _drawerController.Shapes.Clear();
            ShapeDrawer.ResetSize();
            ShapeDrawer.InitializeOccupiedGrid(pictureBox.Width, pictureBox.Height, null);
            ShapeDrawer.ResetNonLiquidPoints();
            listBoxShapesInfo.Items.Clear();
            pictureBox.Invalidate();
        }

        private void ListBoxShapesInfo_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();
                var rect1 = new System.Drawing.Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBoxShapesInfo.ItemHeight);

                using (var clippedRegion = new Region(rect1))
                {
                    e.Graphics.Clip = clippedRegion;
                    e.Graphics.DrawString(text, listBoxShapesInfo.Font, Brushes.Black, rect1);
                }

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.DrawFocusRectangle();
                    var name = text.Split('\n')[0];
                    _selectedShape = _drawerController.GetSelectedShape(name);

                    if (_positioning)
                    {
                        var center = ShapeDrawer.GetCenterPoint(_selectedShape);
                        var targetX = center.X;
                        var targetY = center.Y;
                        var panelWidth = panel.ClientSize.Width;
                        var panelHeight = panel.ClientSize.Height;
                        var scrollX = (targetX - panelWidth / 2);
                        var scrollY = (targetY - panelHeight / 2);
                        scrollX = Math.Max(0, Math.Min(scrollX, pictureBox.Width - panelWidth));
                        scrollY = Math.Max(0, Math.Min(scrollY, pictureBox.Height - panelHeight));
                        panel.AutoScrollPosition = new Point(scrollX, scrollY);
                        panel.Invalidate();
                    }

                    pictureBox.Invalidate();
                }

                e.Graphics.ResetClip();
            }
        }

        private void TextBoxFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void TextBoxTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Square;
            _drawerController.UpdateDrawParamAfterChangingSelectedShape();
        }

        private void ButtonTriangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Triangle;
            _drawerController.UpdateDrawParamAfterChangingSelectedShape();
        }

        private void ButtonRectangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Rectangle;
            _drawerController.UpdateDrawParamAfterChangingSelectedShape();
        }

        private void ButtonHexagon_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Hexagon;
            _drawerController.UpdateDrawParamAfterChangingSelectedShape();
        }

        private void UpdateSelectedButton(Button newSelectedButton)
        {
            if (_selectedButton != null)
            {
                _selectedButton.BackColor = DefaultBackColor;
                _selectedButton.ForeColor = DefaultForeColor;
            }

            _selectedButton = newSelectedButton;
            _selectedButton.BackColor = Color.Blue;
            _selectedButton.ForeColor = Color.White;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _drawerController.Shapes)
            {
                if (shape == _selectedShape)
                {
                    e.Graphics.DrawPolygon(new Pen(Color.Red, 4), shape.Points);
                    _drawerController.DrawNameForShape(shape, e.Graphics);
                }
                else
                    e.Graphics.DrawPolygon(new Pen(Color.Black, 2), shape.Points);
            }
        }

        private void radioButtonIntersecting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIntersecting.Checked)
                _drawerController.DrawingOption = DrawingOption.Intersecting;

            _drawerController.UpdateDrawParamAfterChangingDrawingOptionOrLoadData();
        }

        private void radioButtonNonIntersecting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNonIntersecting.Checked)
                _drawerController.DrawingOption = DrawingOption.NonIntersecting;

            _drawerController.UpdateDrawParamAfterChangingDrawingOptionOrLoadData();
        }

        private void radioButtonEnclosure_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEnclosure.Checked)
                _drawerController.DrawingOption = DrawingOption.Enclosure;

            _drawerController.UpdateDrawParamAfterChangingDrawingOptionOrLoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "JSON файлы (*.json)|*.json";
            saveFileDialog.FileName = "shapes.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ShapesJsonLoader.SaveShapes(_drawerController.Shapes, saveFileDialog.FileName);
                }
                catch (IOException _)
                {
                    ShowErrorMessageBox("File writing error.");
                }
                catch (JsonException _)
                {
                    ShowErrorMessageBox("JSON serialization error.");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "JSON файлы (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var deserializedShapes = ShapesJsonLoader.LoadShapes(openFileDialog.FileName);
                    _drawerController.Shapes = deserializedShapes;
                    _drawerController.Shapes.Sort(new FigureComparer());
                    pictureBox.Invalidate();
                    UpdateListBoxShapesItems();
                }
                catch (IOException _)
                {
                    ShowErrorMessageBox("File reading error.");
                }
                catch (JsonException _)
                {
                    ShowErrorMessageBox("JSON deserialization error.");
                }
                catch (JsonValidationException ex)
                {
                    ShowErrorMessageBox(ex.Message);
                }

                _drawerController.UpdateDrawParamAfterChangingDrawingOptionOrLoadData();
            }
        }

        private void UpdateListBoxShapesItems()
        {
            listBoxShapesInfo.HorizontalExtent = 0;

            foreach (var shape in _drawerController.Shapes)
            {
                var textLength = (int)(TextRenderer.MeasureText(shape.ToString().Split("\n")[1], listBoxShapesInfo.Font).Width * 1.05);

                if (textLength > listBoxShapesInfo.HorizontalExtent)
                    listBoxShapesInfo.HorizontalExtent = textLength;
            }

            listBoxShapesInfo.Items.Clear();

            foreach (var shape in _drawerController.Shapes)
                listBoxShapesInfo.Items.Add(shape);
        }

        public static void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarningMessageBox(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            var verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            var horizontalScrollBarHeight = SystemInformation.HorizontalScrollBarHeight;
            panel.AutoScrollMinSize = pictureBox.Size - new Size(verticalScrollBarWidth, horizontalScrollBarHeight);
            splitContainer1.Panel1MinSize = (int)(Width * 0.65);
            splitContainer1.PerformLayout();
        }

        private void checkBoxPositioning_CheckedChanged(object sender, EventArgs e)
        {
            _positioning = !_positioning;
        }
    }
}