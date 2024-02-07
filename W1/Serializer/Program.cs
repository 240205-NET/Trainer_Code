using System;
using System.IO;

namespace Serializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Serializer running...");

            Menu();

            Console.WriteLine("Application closing...");
        }

        public static void Menu()
        {
            string path = @".\TextFile.txt";
            // create some objects
            Person Lawrence = new Person("Lawrence", 72, 28);

            bool loop = true;
            while(loop)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1: Read from file.");
                Console.WriteLine("2: Write to file.");
                Console.WriteLine("3: Create Xml Record");
                Console.WriteLine("4: Read from Xml Record");
                Console.WriteLine("0: Exit.");

                string? choice = Console.ReadLine(); // the "?" makes it nullable

                switch(choice)
                {
                    case "1": // if (choice == "1")
                        Console.WriteLine("Reading from file...");
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
                        break;

                    case "2":
                        // display/confirm the object
                        Console.WriteLine(Lawrence.ToString());

                        // save to a file as text
                        Console.WriteLine("Writing to file...");
                        string[] text = {Lawrence.ToString()};

                        if( File.Exists(path))
                        {
                            File.AppendAllLines(path,text);
                        }
                        else
                        {
                            File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
                        // File.WriteLine(path, <string>); // WriteLine will operate on a single string
                        }
                        break;

                    case "3":
                        // convert/serialize the object
                        Console.WriteLine(Lawrence.SerializeXML());

                        // save the serialized object to a file
                        string[] text1 = {Lawrence.SerializeXML()};
                        File.WriteAllLines(path, text1);

                        break;

                    case "4":
                        // Read a serialized object back in
                        break;

                    case "0":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
