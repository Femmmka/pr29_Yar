using pr29_Yar.Classes;
using pr29_Yar.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pr29_Yar.Model
{
    public class Films : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("_id");
            }
        }
        private string? _title;
        public string? Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("_title");
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("_date");
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("_time");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(filmsItem =>
                {
                    if (filmsItem is Films filmsObject)
                    {
                        VMFilmsAdd newModel = new(filmsObject, new FilmsContext());
                        MainWindow.init?.frame.Navigate(new View.Films.Add(newModel));
                    }
                });
            }
        }
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Films filmsItem)
                    {
                        using FilmsContext filmsContext = new();
                        filmsContext.Delete(this);
                        MainWindow.init.MainFilms = new View.Films.Main();
                        MainWindow.init.frame.Navigate(MainWindow.init.MainFilms);
                    }
                });
            }
        }
    }
}
