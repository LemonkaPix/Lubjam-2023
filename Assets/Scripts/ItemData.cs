using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Item, 
    Watch,
    Flashlight
}

public class ItemData : MonoBehaviour
{
    public ItemType itemType;
    public int itemId;
    [Header("Other")]
    [SerializeField] GameObject timeTravelController;
    [SerializeField] GameObject[] Cameras;
    public bool canBeToggled;
    PlayerInventory plrInventory;

    private void Start()
    {
        plrInventory = FindObjectOfType<PlayerInventory>();
    }

    public void onClick()
    {
        
        if(itemType == ItemType.Item) 
        {
            plrInventory.inventory.Add(gameObject);
        }
        else if(itemType == ItemType.Watch)
        {
            timeTravelController.GetComponent<TimeTravelBehaviour>().playerHasWatch = true;
        }
        else if(itemType == ItemType.Flashlight)
        {   
            plrInventory.inventory.Add(gameObject);
            Cameras[0].gameObject.SetActive(true);
            Cameras[1].gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
