using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorLock : MonoBehaviour
{
    [SerializeField] UnityEvent onRightCombination;
    [SerializeField] ColorChangeLock[] locks;
    [SerializeField] Color[] rightCombination;

    public void CheckCombination()
    {
        for (int i = 0; i < locks.Length; i++) if (locks[i].currentColor != rightCombination[i]) return;
        Debug.Log("hi");
        onRightCombination.Invoke();

    }
}
