using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using State.Pattern.Example.Annotations;
using Stateless;

namespace State.Pattern.Example.Stateless.Implementation
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private StateMachine<OrderState, OrderActionTrigger> order;
        public ICommand CreateOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand ShipOrderCommand { get; set; }
        public ICommand NewOrderCommand { get; set; }

        public OrderDetailModel OrderDetail { get; set; } = new OrderDetailModel();

        public MainViewModel()
        {
            order = new StateMachine<OrderState, OrderActionTrigger>(OrderState.New);

            order.Configure(OrderState.New)
                .OnEntry(OrderDetail.Reset)
                .Permit(OrderActionTrigger.Create, OrderState.Created)
                .Ignore(OrderActionTrigger.Ship)
                .Ignore(OrderActionTrigger.Cancel);

            order.Configure(OrderState.Created)
                .OnEntry(OrderDetail.Create)
                .Permit(OrderActionTrigger.Cancel, OrderState.Cancelled)
                .Permit(OrderActionTrigger.Ship, OrderState.Shipped)
                .Ignore(OrderActionTrigger.Reset);

            order.Configure(OrderState.Cancelled)
                .OnEntry(OrderDetail.Cancel)
                .Permit(OrderActionTrigger.Reset, OrderState.New)
                .Permit(OrderActionTrigger.Create, OrderState.Created)
                .Ignore(OrderActionTrigger.Ship);

            order.Configure(OrderState.Shipped)
                .OnEntry(OrderDetail.Ship)
                .Permit(OrderActionTrigger.Reset, OrderState.New)
                .Permit(OrderActionTrigger.Create, OrderState.Created)
                .Ignore(OrderActionTrigger.Cancel);

            CreateOrderCommand = new RelayCommand(() => order.Fire(OrderActionTrigger.Create));
            CancelOrderCommand = new RelayCommand(() => order.Fire(OrderActionTrigger.Cancel));
            ShipOrderCommand = new RelayCommand(() => order.Fire(OrderActionTrigger.Ship));
            NewOrderCommand = new RelayCommand(() => order.Fire(OrderActionTrigger.Reset));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum OrderActionTrigger
    {
        Reset, Create, Cancel, Ship
    }

    public enum OrderState
    {
        New, Created, Cancelled, Shipped
    }
}
