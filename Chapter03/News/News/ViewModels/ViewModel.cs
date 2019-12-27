using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace News.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public INavigate Navigation { get; set; } = new Navigator();
    }


    public interface INavigate
    {
        Task NavigateTo(string route);
        Task PushModal(Page page);
        Task PopModal();
    }
}
