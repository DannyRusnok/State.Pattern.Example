using System.ComponentModel;
using System.Runtime.CompilerServices;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public abstract class OrderState : INotifyPropertyChanged
    {
        public abstract void EnterState(OrderContext context);
        public abstract void Reset(OrderContext context);
        public abstract void Create(OrderContext context);
        public abstract void Cancel(OrderContext context);
        public abstract void Ship(OrderContext context);
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}