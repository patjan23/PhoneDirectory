using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneDirectory.Interface
{
   

    public interface IMessageBoxService
    {
        string Show( string caption, string operation, string content);
    }

    public class MessageBoxService : IMessageBoxService
    {
       

        public string Show(string caption, string operation,string content)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            if (operation == "Open")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();


                openFileDialog.Title = caption;
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                openFileDialog.ShowDialog();

                //Get the path of specified file
                filePath = openFileDialog.FileName;


                return filePath;
            }
            else
            {               

                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "unknown.txt";
                // set filters - this can be done in properties as well
                savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                savefile.ShowDialog();
                
                    using (StreamWriter sw = new StreamWriter(savefile.FileName))
                        sw.WriteLine(content);

                return "Done";

            }

        }
    }
}
