using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Operation
{
    public  class FileOperation
    {
        
        public static string FileName { get; set; }

        public static List<string> ReadData()
        {
            List<string> data = new List<string>();
            string textFile = System.Environment.CurrentDirectory + "\\Data.txt";
            FileName = textFile;
            string[] lines = File.ReadAllLines(textFile);
            foreach (var item in lines)
            {
                if (item != "")
                    data.Add(item);
            }
            return data;
        }

        public static List<string> ReadDataFromFile(string fileName)
        {
            FileName = fileName;
            List<string> data = new List<string>();
            if (FileName != null)
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (var item in lines)
                {
                    if( item != "")
                    data.Add(item);
                }
            }
            return data;
        }

        public static void SaveFile(string Content)
        {
            File.WriteAllText(FileName, Content);
        }
    }
}
