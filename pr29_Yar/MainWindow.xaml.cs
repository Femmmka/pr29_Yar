using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows;

namespace pr29_Yar
{
    public partial class MainWindow : Window
    {
        public static MainWindow? init;

        public View.Films.Main MainFilms = new();
        public View.Genres.Main MainGenres = new();
        public MainWindow()
        {
            InitializeComponent();

            init = this;
            frame.Navigate(MainFilms);
        }

        private void OpenCourses(object sender, RoutedEventArgs e) =>
            frame.Navigate(MainFilms);

        private void OpenTeachers(object sender, RoutedEventArgs e) =>
            frame.Navigate(MainGenres);
    }
}
