using System;

namespace State.Pattern.Example.StatePattern.Implementation
{
    public class NewState : OrderState
    {
        public override void EnterState(OrderContext context)
        {
            context.State = "New";
            context.Number = Guid.Empty;
        }

        public override void Reset(OrderContext context) { }

        public override void Create(OrderContext context)
        {
            context.TransitionToState(new CreateState());
        }

        public override void Cancel(OrderContext context) { }

        public override void Ship(OrderContext context) { }
    }
}