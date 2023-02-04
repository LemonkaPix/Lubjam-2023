using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlanksOff : MonoBehaviour
{
    [SerializeField] GameObject[] Planks;
    bool broken = false;
    IEnumerator breakOff()
    {
        broken = true;

        // add rigid body for cool falling off effect
        foreach(GameObject plank in Planks) 
        { 
            plank.AddComponent<Rigidbody>();
        }

        yield return new WaitForSeconds(5);

        // destroy planks so they dont clutter the hierarchy
        foreach (GameObject plank in Planks)
        {
            Destroy(plank);
        }

    }

    void Update()
    {
        if(transform.GetComponent<DoorAnimation>().isLocked == false)
        {
            if(!broken) StartCoroutine(breakOff());

        }
    }
}
