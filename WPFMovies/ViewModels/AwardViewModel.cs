using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFMovies.Annotations;
using WPFMovies.Models;

namespace WPFMovies.ViewModels
{
    public class AwardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Award _award;

        public AwardViewModel(Award award)
        {
            _award = award;
        }

        public string Name
        {
            get => _award.Name;
            set
            {
                _award.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Category
        {
            get => _award.Category;
            set
            {
                _award.Category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}