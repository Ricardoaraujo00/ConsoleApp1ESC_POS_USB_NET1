using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Printer;

namespace ConsoleApp1ESC_POS_USB_NET1
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer("CITIZEN PPU-700");
            printer.Append(HexStringToByteArray("1B 61 01"));
            printer.AlignRight();
            printer.ExpandedMode(PrinterModeState.On);
            printer.Append("Prioritário   ");
            printer.ExpandedMode(PrinterModeState.Off);
            printer.Append("----------------------------------");
            printer.AlignLeft();
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.AlignRight();
            printer.DoubleWidth3();
            printer.Append("          5                  ");
            printer.NormalWidth();
            printer.AlignLeft();
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.Append(".");
            printer.AlignRight();
            printer.Append("----------------------------------");
            printer.Append("Farmácia Santos         ");
            printer.AlignLeft();
            printer.Append(".");
            printer.AlignRight();
            printer.Append("08/06/2020 11:55         ");
            printer.Append("Tempo de espera: 6m        ");

            //Bitmap image = new Bitmap(Bitmap.FromFile(@"c:\logo\logo2.bmp"));
            //printer.Image(image);

            printer.FullPaperCut();
            printer.PrintDocument();
        }

        private static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
    }
}
