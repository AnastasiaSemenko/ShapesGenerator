using Enums.ShapeGenerator;
using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public partial class MainWindow : Form
    {
        private static List<Shape> shapes = new();

        private Button _selectedButton;
        private FigureShape _selectedFigureShape;
        private DrawingOption _selectedDrawingOption;
        private int _from;
        private int _to;
        private int size = 50; //////////////////////////////////////////////////////////////

        public static List<Shape> Shapes { get => shapes; set => shapes = value; }

        public MainWindow()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            UpdateSelectedButton(buttonSquare);
            _selectedFigureShape = FigureShape.Square;
            radioButtonIntersecting.Checked = true;
        }

        private void ButtonGen_Click(object sender, EventArgs e)
        {
            _from = int.Parse(textBoxFrom.Text);
            _to = int.Parse(textBoxTo.Text);
            Drawer.DrawShapes(_from, _to, _selectedFigureShape, _selectedDrawingOption, pictureBox);
            Shapes.Sort(new FigureComparer());
            listBoxShapesInfo.Items.Clear();

            foreach (var shape in Shapes)
                listBoxShapesInfo.Items.Add(shape);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
            listBoxShapesInfo.Items.Clear();
            Shapes.Clear();
            pictureBox.Update();
        }

        private void ListBoxShapesInfo_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();
                var rect1 = new System.Drawing.Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBoxShapesInfo.ItemHeight);
                e.Graphics.DrawString(text, listBoxShapesInfo.Font, Brushes.Black, rect1);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e.DrawFocusRectangle();
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
            _selectedFigureShape = FigureShape.Square;
        }

        private void ButtonTriangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _selectedFigureShape = FigureShape.Triangle;
        }

        private void ButtonRectangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _selectedFigureShape = FigureShape.Rectangle;
        }

        private void ButtonHexagon_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            _selectedFigureShape = FigureShape.Hexagon;
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

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            panel.AutoScrollMinSize = pictureBox.Size;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in Shapes)
                shape.Draw(e.Graphics);
        }

        private void radioButtonIntersecting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIntersecting.Checked)
                _selectedDrawingOption = DrawingOption.Intersecting;
        }

        private void radioButtonNonIntersecting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNonIntersecting.Checked)
                _selectedDrawingOption = DrawingOption.NonIntersecting;
        }

        private void radioButtonEnclosure_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEnclosure.Checked)
                _selectedDrawingOption = DrawingOption.Enclosure;
        }
    }
}