using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ritaripeli
{
    internal class Print
    {
        public static void Line(string text)
        {
            Console.WriteLine(text);
        }
        public static void LineColor(string text, ConsoleColor color)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text, color);
            Console.ForegroundColor = c;
        }

        public static void WriteColor(string text, ConsoleColor color)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text, color);
            Console.ForegroundColor = c;
        }
    }
}