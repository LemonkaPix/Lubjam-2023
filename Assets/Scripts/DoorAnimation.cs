using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator anim;
    public bool trigger;
    public bool isLocked;
    [SerializeField] int keyId;

    PlayerInventory plrInventory;

    void Start()
    {
        anim.SetBool("isOpen", true);
        plrInventory = FindObjectOfType<PlayerInventory>();
    }

    public void onClick()
    {
        if(isLocked)
        {
            foreach (GameObject item in plrInventory.inventory)
            {
                if (item.GetComponent<KeyData>().keyId == keyId)
                {
                    plrInventory.inventory.Remove(item);
                    isLocked = false; break;
                }
            }
            return;
        }


            trigger = anim.GetBool("isOpen");
            if (!trigger)
            {
                anim.SetBool("isOpen", true);
            }
            else
            {
                anim.SetBool("isOpen", false);
            }
        }
}
