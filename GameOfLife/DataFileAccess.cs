using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLife
{
    public class DataFileAccess
    {
        private List<string []> InputFile { get; set; }
        private string FileName { get; set; }

        public DataFileAccess(string fileName)
        {
            FileName = fileName;
            ReadDataFile();
        }

        public void ReadDataFile()
        {
            InputFile = new List<string []>();

            //create path to file in current directory
            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, FileName);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        char[] charArray = sr.ReadLine().ToCharArray();
                        string[] stringArray = Array.ConvertAll(charArray, chr => chr.ToString());
                        InputFile.Add(stringArray);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file.");
                Console.WriteLine(e.Message);
            }
        }

        public string[][] GetFileGrid()
        {
            return InputFile.ToArray();
        }
    }
}

