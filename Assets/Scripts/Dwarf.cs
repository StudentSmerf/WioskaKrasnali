using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : AbstractCharacter
{

    public Dwarf(GameObject obj){
        characterGameObject = obj;
        movementSpeed = 10f;
    }
    public override void Move(float x, float z){
        if(characterGameObject.GetComponent<SelectCharacter>().CheckIfSelected()){
            //cameraGameObject.transform.position = Vector3.MoveTowards(characterGameObject.transform.position, endPosition, movementSpeed * Time.deltaTime);
            characterGameObject.GetComponent<CharacterMovement>().MoveTowardsPoint(x, z, movementSpeed);
        }
    }
}
