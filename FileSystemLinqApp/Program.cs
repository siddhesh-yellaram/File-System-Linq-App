using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemLinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string startFolder = @"C:\Windows\System32";

            DirectoryInfo dir = new DirectoryInfo(startFolder);
            
            //Top 10 Directories in System 32.
            var dirList = dir.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            var dirDet = dir.EnumerateDirectories().Take(10);
            Console.WriteLine("Top 10 Directories in System 32 are:");
            foreach(var f in dirDet) 
            {
                Console.WriteLine("Directory Name: " + f.Name);
            }
            Console.WriteLine();

            //Top 10 files in System 32.
            var fileList = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            var fileDetails = fileList.Where(f => f.Length > 333000).Take(10);
            Console.WriteLine("Top 10 Files in System 32 are:");
            foreach (var f in fileDetails)
            {
                Console.WriteLine("File Name: "+f.Name);
            }
            Console.WriteLine();

            //Top 10 files in Ascending Order
            var fileAscen = fileList.Where(f => f.Length > 450000).OrderBy(f => f.Name).Take(10);
            Console.WriteLine("Top 10 Files in System 32 in ascending order are:");
            foreach (var f in fileAscen)
            {
                Console.WriteLine("File Name: " + f.Name);
            }

            Console.ReadLine();
        }
    }
}
