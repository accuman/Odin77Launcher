using System;
using System.Collections.Generic;
using System.Text;
// using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
//using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Odin77Launcher
{
    class Program
    {
        static public string message = "";
        static public string basePath = "";

        static public bool findBase(string baseName)
        {
            RegistryKey titlesKey = Registry.CurrentUser.OpenSubKey(@"Software\1C\1Cv7\7.7\Titles");
            string[] paths = titlesKey.GetValueNames();
            foreach(string path in paths)
            {
                if(titlesKey.GetValue(path).ToString().ToLower() == baseName)
                {
                    basePath = path;
                    titlesKey.Close();
                    // Console.WriteLine("Base path {0}", basePath);
                    return true;
                }
            }
            titlesKey.Close();
            return false;
        }

        static public bool findProcess()
        {

            return false;
        }
        static bool ProcessInput(string url)
        {
            // Console.WriteLine("Started with {0}", url);
            // odin77://baseName/objReference

            string[] parts = url.Split('/');
            if(parts.Length != 4)
            {
                message = "Неверная ссылка";
                return false;
            }
            // на всякий случай
            if(!parts[0].ToLower().Equals("odin77:"))
            {
                message = "Ошибка имени протокола";
                return false;
            }
            // эт вот чтоб '//' обязательно было =%/
            if(parts[1] != "")
            {
                message = "Ошибка адресации";
                return false;
            }
            // поиск нужной базы в реестре
            if(!findBase(parts[2].ToLower()))
            {
                message = "База с именем "+parts[2]+" не найдена";
                return false;
            }
            // поиск запущенного процесса с нужным путём к базе
            if(!findProcess())
            {
                message = "нет запущенного процесса 1С с нужным путём";
                return false;
            }
            else
            {
                message = "процесс найден, запускаться пока не умею";
                return false;
            }


            // если его нет - запущаем 1С

            // вызов процесса с нужным объектом
            Console.WriteLine("Starting base with {0}", parts[3]);
            return true;
        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Raw command-line: \n\t" + Environment.CommandLine);
            foreach (string s in args)
            {
                if (!ProcessInput(s))
                {
                    MessageBox.Show(message, "Ошибочка вышла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
