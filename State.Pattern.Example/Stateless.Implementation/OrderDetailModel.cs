using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.Stateless.Implementation
{
    public class OrderDetailModel : INotifyPropertyChanged
    {
        public Guid Number { get; private set; }
        public string State { get; private set; }

        public OrderDetailModel()
        {
            Reset();
        }

        public void Reset()
        {
            State = "None";
            Number = Guid.Empty;
        }

        public void Create()
        {
            Number = Guid.NewGuid();
            State = "Created";
        }

        public void Cancel()
        {
            State = "Cancelled";
        }

        public void Ship()
        {
            State = "Shipped";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}