using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyBrainfuckLib.MyBrainfuck;
using static System.Console;

namespace MyBrainfuckConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string i_buf = "++++++++[>++++++++<-]>.++++++++ +.++++++++++ +.";
            WriteLine(ExecuteBrainfuckCode(i_buf));
            ReadKey();
        }
    }
}
