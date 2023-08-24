using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour, IStorageable
{
    [SerializeField] private int[] items;
    [SerializeField] private int[] maxItems;
    private int amountTaken;

    void Start(){
        items = new [] {0, 0, 0, 0, 0};
        maxItems = new  [] {4, 2, 10, 2, 2};
    }
    public float GetX(){
        return this.transform.position.x;
    }
    public float GetZ(){
        return this.transform.position.z;
    }

    public int DepositItem(int amount, int itemId){
        
        if(amount + items[itemId] > maxItems[itemId]){
            amountTaken = maxItems[itemId] - items[itemId];
            items[itemId] = maxItems[itemId];
            return amount - amountTaken;       
        }
        else{
            items[itemId] += amount;
            return 0;   
        }
                
            
        
    }
    public int CollectItem(int amount, int itemId){
        if(items[itemId] - amount <= 0){
            amount = items[itemId];
            items[itemId] = 0;
            return amount;
        }
        else{
            items[itemId] -= amount;
            return amount;
        }
        
    }
    public int ShowItems(int itemId){
        return items[itemId];
    }

}
