using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject dwarf;
    public GameObject mainBuilding;
    public GameObject storageBuilding;
    [SerializeField] private List<AbstractCharacter> characterList;
    [SerializeField] private List<AbstractBuilding> buildingList;
    public static GameStateManager instance;
    private Vector3 targetPosition;
    private bool mainBuildingNotCreated;
    void Start()
    {
        mainBuildingNotCreated = true;
        instance = this;
        characterList = new List<AbstractCharacter>();
        buildingList = new List<AbstractBuilding>();
        for (int i = 0; i < 5; i++)
        {
            GameObject newDwarf = Instantiate(dwarf, GetPosition(), Quaternion.identity);
            Dwarf dwarfClass = new Dwarf(newDwarf);
            characterList.Add(dwarfClass);
            newDwarf.name = "Dwarf " + i;
        }
    }

    

    private Vector3 GetPosition(){
        return new Vector3(Random.Range(0, 15), 0.5f, Random.Range(0, 15));
    }
    public void SetTargetPosition(Vector3 position){
        targetPosition = position;
        foreach (AbstractCharacter character in characterList)
        {
            character.Move(targetPosition.x, targetPosition.z);
        }
    }
    public void CreateBuilding(Vector3 position, int buildingId){
        switch (buildingId)
        {
            case 0:
                if(mainBuildingNotCreated){
                    GameObject newMainBuilding = Instantiate(mainBuilding, position, Quaternion.identity);
                    MainBuilding MBClass = new MainBuilding(newMainBuilding);
                    buildingList.Add(MBClass);
                    mainBuildingNotCreated = false;
                    
                }
                break;
            case 1:
                GameObject newStorageBuilding = Instantiate(storageBuilding, position, Quaternion.identity);
                StorageBuilding StorageClass = new StorageBuilding(newStorageBuilding);
                buildingList.Add(StorageClass);
                break;
                
            default:
                break;
        }
    }

    
}
