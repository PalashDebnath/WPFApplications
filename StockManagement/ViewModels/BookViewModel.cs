using StockManagement.Commands;
using StockManagement.Helpers;
using StockManagement.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System;

namespace StockManagement.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly IFileReader _fileReader;

        public UploadCommand UploadCommand { get; set; }

        public ShowCommand ShowCommand { get; set; }

        public ClearCommand ClearCommand { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        private bool _noStock;

        public bool NoStock
        {
            get { return _noStock; }
            set { _noStock = value; OnPropertyChanged("NoStock"); }
        }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnPropertyChanged("FileName"); }
        }

        public BookViewModel(IFileReader fileReader)
        {
            ShowCommand = new ShowCommand(this);
            UploadCommand = new UploadCommand(this);
            ClearCommand = new ClearCommand(this);
            Books = new ObservableCollection<Book>();
            _fileReader = fileReader;
        }

        public void OpenDialog()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "All csv files (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                FileName = dialog.FileName + " has been successfully uploaded.";
                CallCSVReader(dialog.FileName);
            }
        }

        public void DisplayDescription(string title)
        {
            var book = Books.Where(b => b.Title == title).FirstOrDefault();
            MessageBox.Show(book?.Description, "Title - " + book?.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ModifyBookCollection()
        {
            var books = Books.Where(b => b.InStock == false).ToList();
            foreach (var book in books)
            {
                Books.Remove(book);
            }
            NoStock = false;
        }

        private async void CallCSVReader(string path)
        {
            try
            {
                var books = await _fileReader.Read(path);
                Books.Clear();
                foreach (var book in books)
                {
                    if (!book.InStock)
                        NoStock = true;
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
