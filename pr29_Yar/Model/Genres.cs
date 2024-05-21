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
    public class Genres : INotifyPropertyChanged
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
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("_name");
            }
        }


        private int _filmsId;
        public int FilmsId
        {
            get { return _filmsId; }
            set
            {
                _filmsId = value;
                OnPropertyChanged("_filmsId");
            }
        }

        private Films? _films;
        public Films? Films
        {
            get { return _films; }
            set
            {
                _films = value;
                OnPropertyChanged("_courses");
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
                return new RelayCommand(genresItem =>
                {
                    if (genresItem is Genres genresObject)
                    {
                        using GenresContext genresContext = new();
                        VMGenresAdd newModel = new(genresObject, genresContext);
                        MainWindow.init?.frame.Navigate(new View.Genres.Add(newModel));
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
                    if (obj is Genres genresItem)
                    {
                        using GenresContext genresContext = new();
                        genresContext.Delete(this);
                        MainWindow.init.MainTeachers = new View.Genres.Main();
                        MainWindow.init.frame.Navigate(MainWindow.init.MainGenres);
                    }
                });
            }
        }


    }
}
