using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeGenerator
{
    public class CanvasOverflowException : Exception
    {
        public CanvasOverflowException()
        {
        }

        public CanvasOverflowException(string? message) : base(message)
        {
        }


    }
}
