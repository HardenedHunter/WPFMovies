using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using WPFMovies.Annotations;
using WPFMovies.Commands;
using WPFMovies.Models;

namespace WPFMovies.ViewModels
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MovieViewModel _selectedMovie;

        private bool _isGrouped;

        public ObservableCollection<MovieViewModel> MovieList { get; set; }

        public ICollectionView MoviesView { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand ClearSelectionCommand { get; set; }

        public MovieListViewModel()
        {
            MovieList = new ObservableCollection<MovieViewModel>();
            Initialize();
            InitializeCommands();
            InitializeGrouppedView(); 
        }

        public MovieViewModel SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public bool IsGrouped
        {
            get => _isGrouped;
            set
            {
                _isGrouped = value;
                GroupUnGroup();
                OnPropertyChanged(nameof(IsGrouped));
            }
        }

        private void GroupUnGroup()
        {
            MoviesView.GroupDescriptions.Clear();
            if (IsGrouped)
                MoviesView.GroupDescriptions.Add(new PropertyGroupDescription("Genre"));
        }

        public void DeleteMovie(object student)
        {
            MovieList.Remove(student as MovieViewModel);
            SelectedMovie = null;
        }

        public bool CanExecuteDeleteStudent(object movie)
        {
            return movie is MovieViewModel;
        }


        private void Initialize()
        {
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 1,
                Title = "Interstellar",
                Genre = "Sci-Fi",
                Language = "English",
                BoxOffice = 696264079,
                Year = 2014,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 1,
                        Name = "Oscar",
                        Category = "Best Visual Effects"
                    },
                    new Award
                    {
                        Id = 2,
                        Name = "Bafta",
                        Category = "Best Visual Effects"
                    },
                    new Award
                    {
                        Id = 3,
                        Name = "Saturn",
                        Category = "Best Science Fiction Film"
                    },
                }
            }));
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 2,
                Title = "Roma",
                Genre = "Drama",
                Language = "Spanish",
                BoxOffice = 1140769,
                Year = 2018,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 4,
                        Name = "Oscar",
                        Category = "Best Foreign Language Film of the Year"
                    },
                    new Award
                    {
                        Id = 5,
                        Name = "Oscar",
                        Category = "Best Achievement in Directing"
                    },
                    new Award
                    {
                        Id = 6,
                        Name = "Oscar",
                        Category = "Best Achievement in Cinematography"
                    },
                    new Award
                    {
                        Id = 7,
                        Name = "Bafta",
                        Category = "Best Director - Motion Picture"
                    },
                }
            }));
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 3,
                Title = "A Separation",
                Genre = "Drama",
                Language = "Persian",
                BoxOffice = 22926076,
                Year = 2011,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 8,
                        Name = "Oscar",
                        Category = "Best Foreign Language Film of the Year"
                    },
                    new Award
                    {
                        Id = 9,
                        Name = "Golden Globe",
                        Category = "Best Foreign Language Film"
                    },
                    new Award
                    {
                        Id = 10,
                        Name = "Abu Dhabi Film Festival",
                        Category = "Special Jury Award"
                    },
                }
            }));
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 4,
                Title = "Amour",
                Genre = "Drama",
                Language = "French",
                BoxOffice = 29664140,
                Year = 2012,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 11,
                        Name = "Oscar",
                        Category = "Best Foreign Language Film of the Year"
                    },
                    new Award
                    {
                        Id = 12,
                        Name = "Golden Globe",
                        Category = "Best Foreign Language Film"
                    },
                    new Award
                    {
                        Id = 13,
                        Name = "Bafta",
                        Category = "Best Leading Actress"
                    },
                }
            }));
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 5,
                Title = "Prophet",
                Genre = "Crime",
                Language = "French",
                BoxOffice = 17874044,
                Year = 2009,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 14,
                        Name = "Bafta",
                        Category = "Best Film Not in the English Language"
                    },
                }
            }));
            MovieList.Add(new MovieViewModel(new Movie
            {
                Id = 6,
                Title = "12",
                Genre = "Thriller",
                Language = "Russian",
                BoxOffice = 7537453,
                Year = 2007,
                Awards = new List<Award>
                {
                    new Award
                    {
                        Id = 15,
                        Name = "Venice Film Festival",
                        Category = "Special Golden Lion"
                    },
                }
            }));
        }

        private void InitializeGrouppedView()
        {
            MoviesView = CollectionViewSource.GetDefaultView(MovieList);
        }

        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand(DeleteMovie, CanExecuteDeleteStudent);
            ClearSelectionCommand = new ClearSelectionCommand();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}