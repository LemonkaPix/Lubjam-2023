using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class KeyData : MonoBehaviour
{
    public int keyId;
    PlayerInventory plrInventory;

    private void Start()
    {
        plrInventory = FindObjectOfType<PlayerInventory>();
    }

    public void onClick()
    {
        plrInventory.inventory.Add(gameObject);
        gameObject.SetActive(false);
    }
}
