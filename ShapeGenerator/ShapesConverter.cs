using Microsoft.VisualBasic.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShapeGenerator.Shapes;
using Newtonsoft.Json.Linq;
using Enums.ShapeGenerator;
using Newtonsoft.Json;

namespace ShapeGenerator
{
    public class ShapesConverter : JsonCreationConverter<Shape>
    {
        protected override Shape Create(Type objectType, JObject jObject)
        {
            switch ((FigureShape)jObject.Type)
            {
                case FigureShape.Hexagon:
                    return new Hexagon();
                case FigureShape.Rectangle:
                    return new Shapes.Rectangle();
                case FigureShape.Square:
                    return new Square();
                case FigureShape.Triangle:
                    return new Triangle();
            }
            return null;
        }

    }
}
