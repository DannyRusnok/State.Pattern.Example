using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using State.Pattern.Example.Annotations;
using State.Pattern.Example.StatePattern.Implementation;

namespace State.Pattern.Example.Basic.Implementation
{
    public class OrderDetailModel : INotifyPropertyChanged
    {
        private bool isCreateable;
        private bool isShippable;
        private bool isCancelable;
        private bool isResetable;

        public Guid Number { get; private set; }
        public string State { get; private set; }

        public OrderDetailModel()
        {
            isCreateable = true;
            State = "None";
            Number = Guid.Empty;
        }

        public void Reset()
        {
            if (isResetable)
            {
                isResetable = true;
                isCreateable = true;
                isCancelable = false;
                isShippable = false;
                State = "None";
                Number = Guid.Empty;
            }
        }

        public void Create()
        {
            if (isCreateable)
            {
                isResetable = false;
                isCreateable = false;
                isCancelable = true;
                isShippable = true;
                Number = Guid.NewGuid();
                State = "Created";
            }
        }

        public void Cancel()
        {
            if (isCancelable)
            {
                isResetable = true;
                isCancelable = false;
                isCreateable = true;
                isShippable = false;
                State = "Cancelled";
            }

        }

        public void Ship()
        {
            if (isShippable)
            {
                isResetable = true;
                isCreateable = true;
                isCancelable = false;
                isShippable = false;
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