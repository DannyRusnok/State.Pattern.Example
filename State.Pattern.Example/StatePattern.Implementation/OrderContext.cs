using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public class OrderContext : INotifyPropertyChanged
    {
        public Guid Number { get; set; }
        public string State { get; set; }
        public OrderState CurrentState { get; set; }

        public OrderContext()
        {
            CurrentState = new NewState();
        }

        public void TransitionToState(OrderState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}