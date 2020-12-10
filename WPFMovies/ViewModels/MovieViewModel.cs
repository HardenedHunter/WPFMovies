using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFMovies.Annotations;
using WPFMovies.Models;

namespace WPFMovies.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Movie _movie;

        public MovieViewModel(Movie movie)
        {
            _movie = movie;
            InitializeAwards();
        }

        public string Title
        {
            get => _movie.Title;
            set
            {
                _movie.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Genre
        {
            get => _movie.Genre;
            set
            {
                _movie.Genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public string Language
        {
            get => _movie.Language;
            set
            {
                _movie.Language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        public ulong BoxOffice
        {
            get => _movie.BoxOffice;
            set
            {
                _movie.BoxOffice = value;
                OnPropertyChanged(nameof(BoxOffice));
            }
        }

        public uint Year
        {
            get => _movie.Year;
            set
            {
                _movie.Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public ObservableCollection<AwardViewModel> Awards { get; set; }

        private void InitializeAwards()
        {
            Awards = new ObservableCollection<AwardViewModel>();
            _movie.Awards.ForEach(r => Awards.Add(new AwardViewModel(r)));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}