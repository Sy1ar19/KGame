using UnityEngine;

public abstract class InputService : IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    protected const string Button = "Fire";

    public abstract Vector2 Axis { get; }

    public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(Button);
/*    protected static Vector2 SimpleInputAxis() => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));*/
    protected static Vector2 SimpleInputAxis()
    {
        return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}


