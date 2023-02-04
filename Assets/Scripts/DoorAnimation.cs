using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    public bool trigger;
    public bool isLocked;
    public int keyId;


    void Start()
    {
        animator.SetBool("isOpen", true);

    }

    public void onClick()
    {
        if (isLocked)
        {

            return;
        }


        trigger = animator.GetBool("isOpen");
        if (!trigger)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
        }
    }
}
