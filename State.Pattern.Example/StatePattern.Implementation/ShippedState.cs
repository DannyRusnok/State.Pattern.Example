using System;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public class ShippedState : OrderState
    {
        public override void EnterState(OrderContext context)
        {
            context.State = "Shipped";
        }

        public override void Reset(OrderContext context)
        {
            context.TransitionToState(new NewState());
        }

        public override void Create(OrderContext context)
        {
            context.TransitionToState(new CreateState());
        }

        public override void Cancel(OrderContext context) { }

        public override void Ship(OrderContext context) { }
    }
}