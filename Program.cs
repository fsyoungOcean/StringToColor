using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace StringToColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyColorName = "Blue";

            Console.WriteLine("使用Switch來設計方法");

            StringToColor foo = new StringToColor();
            Color fooColor = foo.Transfer(MyColorName);

            Console.WriteLine($"{MyColorName} = A:{fooColor.A} R:{fooColor.R} G:{fooColor.G} B:{fooColor.B}");

            Console.WriteLine("Pree any key for continueing....");

            Console.ReadKey();
        }
    }

    public interface IColorFromArgb
    {
        Color ColorFromArgb();
    }

    public class ColorRed : IColorFromArgb
    {
        public static string Name { get { return "red"; } }
        public Color ColorFromArgb()
        {
            return Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
        }
    }

    public class ColorGreen : IColorFromArgb
    {
        public static string Name { get { return "green"; } }

        public Color ColorFromArgb()
        {
            return Color.FromArgb(0xFF, 0x80, 0x80, 0x80);
        }
    }

    public class ColorBlue : IColorFromArgb
    {
        public static string Name { get { return "blue"; } }

        public Color ColorFromArgb()
        {
            return Color.FromArgb(0xFF, 0x00, 0x00, 0xFF);
        }
    }


    public class StringToColor
    {
        private Dictionary<string, IColorFromArgb> StringColorMap = new Dictionary<string, IColorFromArgb>();

        public StringToColor()
        {
            Init();
        }

        private void Init()
        {
            StringColorMap.Add(ColorRed.Name, new ColorRed());
            StringColorMap.Add(ColorGreen.Name, new ColorGreen());
            StringColorMap.Add(ColorBlue.Name, new ColorBlue());
        }

        public Color Transfer(string name)
        {
            if (StringColorMap.TryGetValue(name.ToLower(), out IColorFromArgb transferResult) == false)
            {
                throw new ArgumentException("不正確的顏色名稱");
            }

            return transferResult.ColorFromArgb();
        }
    }

}
