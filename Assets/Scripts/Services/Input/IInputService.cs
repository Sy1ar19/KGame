using UnityEngine;

public partial interface IInputService
{
    Vector2 Axis { get; }

    bool IsAttackButtonUp();
}
