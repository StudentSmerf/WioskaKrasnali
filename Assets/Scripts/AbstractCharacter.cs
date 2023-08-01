using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacter
{
    public GameObject characterGameObject;
    public float movementSpeed;

    public virtual void Move(float x, float z){}
}
