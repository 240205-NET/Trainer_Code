using System;
using System.IO;

namespace Serializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Serializer running...");

            // create some objects
            Person Lawrence = new Person("Lawrence", 72, 28);

            // display/confirm the object
            Console.WriteLine(Lawrence.ToString());

            // save to a file as text
            string[] text = {Lawrence.ToString()};
            string path = @".\TextFile.txt";
            if( File.Exists(path))
            {
                File.AppendAllLines(path,text);
            }
            else
            {
                File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
               // File.WriteLine(path, <string>); // WriteLine will operate on a single string
            }

            // read from the file
            if(File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
            // convert/serialize the object
            Console.WriteLine(Lawrence.SerializeXML());

            // save the serialized object to a file
            string[] text1 = {Lawrence.SerializeXML()};
            File.WriteAllLines(path, text1);
        }
    }
}