using System.Text;

namespace ShapeGenerator.Shapes
{
    public abstract class Shape
    {
        public Point StartPoint { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Point[] Points { get; set; }
        public int Size { get; set; }

        public abstract Point[] CalculatePoints();
        public override string ToString()
        {
            var resultValue = new StringBuilder();
            resultValue.AppendLine($"{Name} {Id}");

            foreach (var p in Points) 
                resultValue.Append($"{p.X} {p.Y} ");

            return resultValue.ToString();
        }
    }
}
