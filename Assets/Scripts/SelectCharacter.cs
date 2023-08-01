using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    private bool selected;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            selected = false;
        }
    }
    public void OnTriggerEnter(Collider col){
        if(col.tag == "Pointer"){
            selected = true;
            Debug.Log(this.gameObject.name + "sel");
        }
        //Debug.Log(this.gameObject.name + "sel");

    }

    public bool CheckIfSelected(){
        return selected;
    }
}
