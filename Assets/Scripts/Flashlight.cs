using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    PlayerInventory plrInventory;
    bool enabled = false;
    bool onCooldown = false;
    float equipCooldown = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        plrInventory = FindObjectOfType<PlayerInventory>();
    }

    IEnumerator flashLight()
    {
        Light light = transform.GetComponent<Light>();
        if(enabled)
        {
            light.enabled = false;
            enabled = false;
            // unequip
        }
        else
        {
            light.enabled = true;
            enabled = true;
            // equip
        }

        onCooldown = true;
        yield return new WaitForSeconds(equipCooldown);
        onCooldown = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (onCooldown) return;
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            foreach(GameObject item in plrInventory.inventory) 
            {
                ItemData itemData = item.GetComponent<ItemData>();
                if (itemData.itemType == ItemType.Flashlight && itemData.canBeToggled) StartCoroutine(flashLight());
            }
        }
        transform.rotation = transform.parent.rotation;
    }
}
