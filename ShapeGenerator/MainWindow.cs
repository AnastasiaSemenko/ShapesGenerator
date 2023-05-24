using Enums.ShapeGenerator;
using Newtonsoft.Json;
using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace ShapeGenerator
{
    public partial class MainWindow : Form
    {
        private DrawerController _drawerController;
        private Button _selectedButton;
        private Shape _selectedShape;

        public MainWindow()
        {
            InitializeComponent();
            MinimumSize = new Size(1050, 550);
            _drawerController = new DrawerController(pictureBox);
            WindowState = FormWindowState.Maximized;
            UpdateSelectedButton(buttonSquare);
            _drawerController.FigureShape = FigureShape.Square;
            radioButtonIntersecting.Checked = true;
            splitContainer1.Panel2MinSize = listBoxShapesInfo.Width;
            listBoxShapesInfo.ItemHeight = listBoxShapesInfo.Font.Height * 2;
        }

        private void ButtonGen_Click(object sender, EventArgs e)
        {
            _selectedShape = null;
            var from = int.Parse(textBoxFrom.Text);
            var to = int.Parse(textBoxTo.Text);

            if (from > to)
            {
                ShowWarningMessageBox("The 'From' value cannot be greater than the 'Tо' value.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            _drawerController.From = int.Parse(textBoxFrom.Text);
            _drawerController.To = int.Parse(textBoxTo.Text);

            try
            {
                _drawerController.DrawShapes();
            }
            catch (CanvasOverflowException ex)
            {
                ShowWarningMessageBox(ex.Message);
            }

            pictureBox.Invalidate();
            UpdateListBoxShapesItems();

            if (_drawerController.DrawingOption == DrawingOption.Enclosure)
            {
                labelMaxNestingLevel.Text = "Max nesting level - " + _drawerController.GetMaxNestingLevel();
                labelMaxNestingLevel.Visible = true;
            }
            else
                labelMaxNestingLevel.Visible = false;

            Cursor = Cursors.Default;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            labelMaxNestingLevel.Visible = false;
            _selectedShape = null;
            _drawerController.ClearShapes();
            listBoxShapesInfo.Items.Clear();
            pictureBox.Invalidate();
        }

        private void ListBoxShapesInfo_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();
                var textSize = e.Graphics.MeasureString(text, listBoxShapesInfo.Font);
                listBoxShapesInfo.HorizontalExtent = (int)Math.Ceiling(textSize.Width);
                var rect1 = new System.Drawing.Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBoxShapesInfo.ItemHeight);
                e.Graphics.SetClip(rect1);
                e.Graphics.DrawString(text, listBoxShapesInfo.Font, Brushes.Black, rect1);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.DrawFocusRectangle();
                    var name = text.Split('\n')[0];
                    _selectedShape = _drawerController.GetSelectedShape(name);
                    pictureBox.Invalidate();
                }

                e.Graphics.ResetClip();
            }*/


            e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();
                var textSize = e.Graphics.MeasureString(text, listBoxShapesInfo.Font);
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
                    pictureBox.Invalidate();
                }

                e.Graphics.ResetClip();
            }

            /*e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();
                var textSize = e.Graphics.MeasureString(text, listBoxShapesInfo.Font);
                var rect1 = new System.Drawing.Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBoxShapesInfo.ItemHeight);

                // Проверяем, выходит ли текст за пределы элемента
                bool isTextClipped = textSize.Width > e.Bounds.Width;

                // Если текст выходит за пределы элемента, устанавливаем горизонтальную полосу прокрутки
                if (isTextClipped)
                {
                    listBoxShapesInfo.HorizontalScrollbar = true;
                    listBoxShapesInfo.HorizontalExtent = (int)Math.Ceiling(textSize.Width);
                }
                else
                {
                    listBoxShapesInfo.HorizontalScrollbar = false;
                }

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
                    pictureBox.Invalidate();
                }

                e.Graphics.ResetClip();
            }*/




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
        }

        private void ButtonTriangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Triangle;
        }

        private void ButtonRectangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Rectangle;
        }

        private void ButtonHexagon_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _drawerController.FigureShape = FigureShape.Hexagon;
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
        }

        private void radioButtonNonIntersecting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNonIntersecting.Checked)
                _drawerController.DrawingOption = DrawingOption.NonIntersecting;
        }

        private void radioButtonEnclosure_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEnclosure.Checked)
                _drawerController.DrawingOption = DrawingOption.Enclosure;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Сохранить файл";
                saveFileDialog.Filter = "JSON файлы (*.json)|*.json";
                saveFileDialog.FileName = "shapes.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _drawerController.SaveShapes(saveFileDialog);
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
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = "JSON файлы (*.json)|*.json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _drawerController.LoadShapes(openFileDialog);
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
                }
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

        private void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarningMessageBox(string message)
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
    }
}