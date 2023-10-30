using Assets.Scripts.Ifrastructure.Services;
using UnityEngine;

public partial interface IInputService : IService
{
    Vector2 Axis { get; }

    bool IsAttackButtonUp();
}
