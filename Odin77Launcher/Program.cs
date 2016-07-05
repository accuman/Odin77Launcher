using System;
using System.Collections.Generic;
using System.Text;
// using System.Threading.Tasks;
using Microsoft.Win32;

namespace Odin77Launcher
{
    class Program
    {
        static string ProcessInput(string s)
        {
            // TODO Verify and validate the input 
            // string as appropriate for your application.
            Console.WriteLine(s);
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Raw command-line: \n\t" + Environment.CommandLine);
            foreach (string s in args)
            {
                ProcessInput(s);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
