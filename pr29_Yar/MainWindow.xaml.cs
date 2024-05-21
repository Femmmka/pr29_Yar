using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
