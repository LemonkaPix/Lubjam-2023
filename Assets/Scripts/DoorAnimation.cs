using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator anim;
    public bool trigger;
    public bool isLocked;
    public int keyId;


    void Start()
    {
        anim.SetBool("isOpen", true);
        
    }

    public void onClick()
    {
        if(isLocked)
        {
            
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