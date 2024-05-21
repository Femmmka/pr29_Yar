using System.Windows.Controls;


namespace pr29_Yar.View.Films
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add(object? Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}
