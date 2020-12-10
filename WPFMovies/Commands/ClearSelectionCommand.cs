using System;
using System.Windows.Input;
using WPFMovies.ViewModels;

namespace WPFMovies.Commands
{
    public class ClearSelectionCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter is MovieListViewModel;
        }

        public void Execute(object parameter)
        {
            ((MovieListViewModel) parameter).SelectedMovie = null;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}