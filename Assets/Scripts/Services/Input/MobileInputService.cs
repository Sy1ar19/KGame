using UnityEngine;

public partial interface IInputService
{
    class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}

