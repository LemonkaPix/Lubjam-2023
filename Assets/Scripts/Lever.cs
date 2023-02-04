using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] GameObject wallToRemove;
    [SerializeField] GameObject[] levers;

    public void onClick()
    {
        wallToRemove.SetActive(false);
        levers[0].SetActive(false);
        levers[1].SetActive(true);
    }

}
