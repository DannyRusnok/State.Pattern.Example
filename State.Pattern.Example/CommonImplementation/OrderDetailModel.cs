using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using State.Pattern.Example.Annotations;

namespace State.Pattern.Example.CommonImplementation
{
    public class OrderDetailModel : INotifyPropertyChanged
    {
        public Guid Number { get; private set; }
        public bool IsCreateable { get; private set; }
        public bool IsShippable { get; private set; }
        public bool IsCancelable { get; private set; }
        public bool IsResetable { get; private set; }
        public string State { get; private set; }

        public OrderDetailModel()
        {
            IsCreateable = true;
            State = "None";
            Number = Guid.Empty;
        }

        public void Reset()
        {
            if (State == "Shipped" || State == "Cancelled")
            {
                IsResetable = true;
                IsCreateable = true;
                IsCancelable = false;
                IsShippable = false;
                State = "None";
                Number = Guid.Empty;
            }
        }

        public void Create()
        {
            if (State == "None")
            {
                IsResetable = false;
                IsCreateable = false;
                IsCancelable = true;
                IsShippable = true;
                Number = Guid.NewGuid();
                State = "Created";
            }
        }

        public void Cancel()
        {
            if (State == "Created")
            {
                IsResetable = true;
                IsCancelable = false;
                IsCreateable = false;
                IsShippable = false;
                State = "Cancelled";
            }

        }

        public void Ship()
        {
            if (State == "Created")
            {
                IsResetable = true;
                IsCreateable = false;
                IsCancelable = false;
                IsShippable = false;
                State = "Shipped";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}