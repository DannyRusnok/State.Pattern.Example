using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.CommonImplementation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand CreateOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand ShipOrderCommand { get; set; }
        public ICommand NewOrderCommand { get; set; }

        public OrderDetailModel OrderDetail { get; set; } = new OrderDetailModel();

        public MainViewModel()
        {
            CreateOrderCommand = new RelayCommand(OrderDetail.Create);
            CancelOrderCommand = new RelayCommand(OrderDetail.Cancel);
            ShipOrderCommand = new RelayCommand(OrderDetail.Ship);
            NewOrderCommand = new RelayCommand(OrderDetail.Reset);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
