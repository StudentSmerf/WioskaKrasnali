using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float speed;
    private float posX;
    private float posZ;
    private float offsetX;
    private float offsetZ;
    public void MoveTowardsPoint(float x, float z, float movementSpeed){
        posX = x;
        posZ = z;
        speed = movementSpeed;
        offsetX = Random.Range(-2, 2);
        offsetZ = Random.Range(-2, 2);
    }
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX + offsetX, 0.5f, posZ + offsetZ), speed * Time.deltaTime);

    }
}
