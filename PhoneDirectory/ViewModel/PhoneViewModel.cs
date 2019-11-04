using PhoneDirectory.Interface;
using PhoneDirectory.Model;
using PhoneDirectory.Operation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneDirectory.ViewModel
{
     public class PhoneViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Phone> Phonebook { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public IMessageBoxService MessageBoxService { get; set; }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set {
                RaisePropertyChanged("FileName");
                _fileName = value;
            }
        }


        ICommand _command;

        public ICommand RemoveCommand
        {
            get
            {
                if (_command == null)
                {
                    _command = new DelegateCommand( o => true, o => { DeleteSelected(); });
                }
                return _command;
            }
        }

        ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new DelegateCommand(o => true, o => { OpenFile(); });
                }
                return _loadCommand;
            }
        }

        ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DelegateCommand(o => true, o => { SaveFile(); });
                }
                return _saveCommand;
            }
        }

        ICommand _saveAsCommand;

        public ICommand SaveAsCommand
        {
            get
            {
                if (_saveAsCommand == null)
                {
                    _saveAsCommand = new DelegateCommand(o => true, o => { SaveAsFile(); });
                }
                return _saveAsCommand;
            }
        }

       

      
        private Phone _selectedItem;
        public Phone SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PhoneViewModel()
        {

           
            Phonebook = new ObservableCollection<Phone>();
            foreach (string item in FileOperation.ReadData())
            {
                string[] details = item.Split(',');
                Phonebook.Add(new Phone
                {
                    Name = details[0].Trim(),
                    Address = details[1].Trim(),
                    Number = details[2].Trim(),
                    IsActive = (details[3].Trim().ToUpper() == "TRUE") ? true : false
                });
            }   
        }

        private void DeleteSelected()
        {
            if (null != SelectedItem)
            {
                Phonebook.Remove(SelectedItem);
            }
        }

        public void SaveAsFile()
        {
            string text = GenerateText();
            FileName = MessageBoxService.Show("Save File", "Save", text);

        }

        public void SaveFile()
        {
            string text = GenerateText();

            FileOperation.SaveFile(text);
        }

        private string GenerateText()
        {
            string text = string.Empty;
            foreach (var item in Phonebook)
            {
                var status = item.IsActive ? "True" : "False";
                text = text + item.Name + ",\t" + item.Address + ",\t" + item.Number + ",\t" +
                       status + Environment.NewLine;
            }

            return text;
        }


        public void OpenFile()
        {
            var result = MessageBoxService.Show("Open File","Open","");
            if (result != null)
            {
                Phonebook.Clear();
                foreach (string item in FileOperation.ReadDataFromFile(result))
                {
                    string[] details = item.Split(',');
                    Phonebook.Add(new Phone
                    {
                        Name = details[0].Trim(),
                        Address = details[1].Trim(),
                        Number = details[2].Trim(),
                        IsActive = (details[3].Trim().ToUpper() == "TRUE") ? true : false
                    });
                }
            }
        }
    }
}
