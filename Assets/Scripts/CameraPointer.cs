using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraPointer.CameraPointerState;

public class CameraPointer : MonoBehaviour
{
    [SerializeField] private GameObject cameraGameObject;
    [SerializeField] private GameObject sphereGameObject;
    [SerializeField] private GameObject MainBuildingOutline;
    [SerializeField] private GameObject StorageBuildingOutline;
    public GameObject sphere;
    public GameObject buildingOutline;
    

    public Vector3 originPoint;

    private Vector3 direction;
    private Vector3 worldPosition;
    private Vector3 screenPosition;
    private Vector3 defaultPointerPosition = new Vector3(0, -20, 0);

    public int selectedBuildingId;

    private int amountToTransfer;
    private int itemId;

    private IStorageable sender;
    private IStorageable reciver;

    public enum CameraPointerState
    {
        moveCharacters=0,
        placeBuildings,
        accesStorage
    }

    public CameraPointerState state;
    void Start(){
        sphere = Instantiate(sphereGameObject, defaultPointerPosition, Quaternion.identity);
        state = moveCharacters;
        amountToTransfer = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            state = accesStorage;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            state = moveCharacters;
        }
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        direction = worldPosition - cameraGameObject.transform.position;
        RaycastHit hit;
        if(Physics.Raycast(cameraGameObject.transform.position, direction, out hit)){
            switch (state)
            {
                case moveCharacters:
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
                    break;
                case placeBuildings:
                    if(Input.GetButtonDown("Fire1")){
                        originPoint = hit.point;
                        Debug.Log(originPoint);
                        GameStateManager.instance.CreateBuilding(originPoint, selectedBuildingId);
                        Destroy(buildingOutline);
                        state = moveCharacters;
                    }
                    if(hit.transform.tag == "Ground"){
                        buildingOutline.transform.position = hit.point;
                    }
                    
                    if(Input.GetButtonDown("Fire2")){
                        state = moveCharacters;
                        Destroy(buildingOutline);
                    }
                    break;
                case accesStorage:
                    
                    if(hit.transform.gameObject.TryGetComponent(out IStorageable obj)){
                        if(Input.GetButtonDown("Fire1")){
                            sender = obj;
                        }
                        if(Input.GetButtonDown("Fire2")){
                            reciver = obj;
                        }
                        if(Input.GetKeyDown(KeyCode.Alpha1) && sender != null && reciver != null){
                            itemId = 0;
                            Vector3 senderPos = new Vector3(sender.GetX(), 0f, sender.GetZ());
                            Vector3 reciverPos = new Vector3(reciver.GetX(), 0f, reciver.GetZ());
                            Vector3 distance = senderPos - reciverPos;
                            if(distance.magnitude > 2f){
                                //do nothing
                                Debug.Log("Too far to reach!");
                            }
                            else{
                                sender.DepositItem(reciver.DepositItem(sender.CollectItem(amountToTransfer, itemId), itemId), itemId); 
                                Debug.Log(sender + " send " + amountToTransfer + " to " + reciver);
                            }
                            
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        
        
    }
    public void EnterBuildingState(int Id){
        selectedBuildingId = Id;
        switch (Id)
        {
            case 0:
                buildingOutline = Instantiate(MainBuildingOutline, defaultPointerPosition, Quaternion.identity);
                break;
            case 1:
                buildingOutline = Instantiate(StorageBuildingOutline, defaultPointerPosition, Quaternion.identity);
                break;
            default:
                break;
        }
        
        
        state = placeBuildings;
    }
}
