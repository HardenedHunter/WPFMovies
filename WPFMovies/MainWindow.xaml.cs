using System.Windows;
using WPFMovies.ViewModels;

namespace WPFMovies
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MovieListViewModel();
        }
    }
}
