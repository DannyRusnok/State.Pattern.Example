using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand CreateOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand ShipOrderCommand { get; set; }
        public ICommand NewOrderCommand { get; set; }

        public OrderContext OrderContext { get; set; } = new OrderContext();

        public MainViewModel()
        {
            CreateOrderCommand = new RelayCommand(() => OrderContext.CurrentState.Create(OrderContext));
            CancelOrderCommand = new RelayCommand(() => OrderContext.CurrentState.Create(OrderContext));
            ShipOrderCommand = new RelayCommand(() => OrderContext.CurrentState.Create(OrderContext));
            NewOrderCommand = new RelayCommand(() => OrderContext.CurrentState.Create(OrderContext));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
