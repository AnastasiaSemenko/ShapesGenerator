using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator
{
    public partial class MainWindow : Form
    {
        private Button selectedButton;
        private Type selectedTypeShape;
        private Random random = new Random();

        public static List<Shape> shapes = new List<Shape>();
        public int from;
        public int to;
        public int size = 50;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            from = int.Parse(textBoxFrom.Text);
            to = int.Parse(textBoxTo.Text);
            var count = random.Next(from, to);
            int maxX;
            int maxY;

            if (selectedTypeShape == null)
                return; //

            switch (selectedTypeShape.Name)
            {
                case "Square":
                    maxX = pictureBox1.Width - size;
                    maxY = pictureBox1.Height - size;

                    for (int i = 0; i < count; i++)
                    {
                        var square = new Square(size);
                        var point = new Point(random.Next(maxX), random.Next(maxY));
                        square.Draw(point, pictureBox1.CreateGraphics());
                        shapes.Add(square);
                        listBoxShapesInfo.Items.Add(square);
                    }

                    break;
                case "Triangle":
                    maxX = pictureBox1.Width - size;
                    maxY = (int)Math.Ceiling(pictureBox1.Height - size * Math.Sqrt(3) / 2);

                    for (int i = 0; i < count; i++)
                    {
                        var triangle = new Triangle(size);
                        var tpoint = new Point(random.Next(maxX), random.Next(maxY));
                        triangle.Draw(tpoint, pictureBox1.CreateGraphics());
                        shapes.Add(triangle);
                        listBoxShapesInfo.Items.Add(triangle);
                    }

                    break;
                case "Rectangle":
                    maxX = pictureBox1.Width - size * 2;
                    maxY = pictureBox1.Height - size;

                    for (int i = 0; i < count; i++)
                    {
                        var rectangle = new Shapes.Rectangle(size);
                        var rpoint = new Point(random.Next(maxX), random.Next(maxY));
                        rectangle.Draw(rpoint, pictureBox1.CreateGraphics());
                        shapes.Add(rectangle);
                        listBoxShapesInfo.Items.Add(rectangle);
                    }

                    break;
                case "Hexagon":
                    maxX = pictureBox1.Width - size * 2;
                    maxY = pictureBox1.Height - size * 2;

                    for (int i = 0; i < count; i++)
                    {
                        var hexagon = new Hexagon(size);
                        var hpoint = new Point(random.Next(maxX), random.Next(maxY));
                        hexagon.Draw(hpoint, pictureBox1.CreateGraphics());
                        shapes.Add(hexagon);
                        listBoxShapesInfo.Items.Add(hexagon);
                    }

                    break;
                default:
                    Debug.WriteLine("Attempt to draw shapes of unknown type");
                    break;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Update();
            listBoxShapesInfo.Items.Clear();
            shapes.Clear();
        }

        private void listBoxShapesInfo_DrawItem(object sender, DrawItemEventArgs e)
        {

            e.DrawBackground();

            if (e.Index >= 0)
            {
                var text = listBoxShapesInfo.Items[e.Index].ToString();

                //e.Bounds.Height = size.Height * 2;
                RectangleF rect1 = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBoxShapesInfo.ItemHeight);
                e.Graphics.DrawString(text, listBoxShapesInfo.Font, Brushes.Black, rect1);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.DrawFocusRectangle();
                }
                Debug.WriteLine(e.Bounds + " " + rect1.Height + " " + rect1.Width);
            }

        }

        private void textBoxFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void textBoxTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            selectedTypeShape = typeof(Square);
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            selectedTypeShape = typeof(Triangle);
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            selectedTypeShape = typeof(Shapes.Rectangle);
        }

        private void buttonHexagon_Click(object sender, EventArgs e)
        {
            UpdateSelectedButton((Button)sender);
            selectedTypeShape = typeof(Hexagon);
        }

        private void UpdateSelectedButton(Button newSelectedButton)
        {
            if (selectedButton != null)
            {
                selectedButton.BackColor = DefaultBackColor;
                selectedButton.ForeColor = DefaultForeColor;
            }

            selectedButton = newSelectedButton;
            selectedButton.BackColor = Color.Blue;
            selectedButton.ForeColor = Color.White;
        }
    }
}