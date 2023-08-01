using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject dwarf;
    [SerializeField] private List<AbstractCharacter> characterList;
    public static GameStateManager instance;
    private Vector3 targetPosition;
    void Start()
    {
        instance = this;
        characterList = new List<AbstractCharacter>();
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

    
}
