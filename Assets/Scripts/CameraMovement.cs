using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey("w")){
            transform.Translate(Vector3.forward * 15f * Time.deltaTime);
        }
        if(Input.GetKey("s")){
            transform.Translate(-Vector3.forward * 15f * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            transform.Translate(-Vector3.right * 15f * Time.deltaTime);
        }
        if(Input.GetKey("d")){
            transform.Translate(Vector3.right * 15f * Time.deltaTime);
        }

        
    }
}
