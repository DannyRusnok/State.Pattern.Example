using System;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public class CreateState : OrderState
    {
        public override void EnterState(OrderContext context)
        {
            context.State = "Created";
            context.Number = Guid.NewGuid();
        }

        public override void Reset(OrderContext context) { }

        public override void Create(OrderContext context) { }

        public override void Cancel(OrderContext context)
        {
            context.TransitionToState(new CancelState());
        }

        public override void Ship(OrderContext context)
        {
            context.TransitionToState(new ShippedState());
        }
    }
}