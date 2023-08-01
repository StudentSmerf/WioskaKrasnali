using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    [SerializeField] private GameObject cameraGameObject;
    [SerializeField] private GameObject sphereGameObject;
    public Vector3 originPoint;
    [SerializeField] public GameObject sphere;

    private Vector3 direction;
    private Vector3 worldPosition;
    private Vector3 screenPosition;
    private Vector3 defaultPointerPosition = new Vector3(0, -20, 0);
    void Start(){
        sphere = Instantiate(sphereGameObject, defaultPointerPosition, Quaternion.identity);
    }

    void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        direction = worldPosition - cameraGameObject.transform.position;
        RaycastHit hit;
        if(Physics.Raycast(cameraGameObject.transform.position, direction, out hit)){
            if(Input.GetButtonDown("Fire1")){
                originPoint = hit.point;
                sphere.transform.position = originPoint;
            }
            if(Input.GetButton("Fire1")){
                sphere.transform.localScale = new Vector3((originPoint - hit.point).magnitude, (originPoint - hit.point).magnitude, (originPoint - hit.point).magnitude);
            }
            if(Input.GetButtonUp("Fire1")){
                sphere.transform.localScale = new Vector3(1, 1, 1);
                sphere.transform.position = defaultPointerPosition;
            }
            if(Input.GetButtonDown("Fire2")){
                GameStateManager.instance.SetTargetPosition(hit.point);
            }
        }

        
        
    }
}
