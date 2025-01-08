using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocomotion
{
    void HandlePlayerMovement(float movementSpeed);
    void HandleRotation();
}
