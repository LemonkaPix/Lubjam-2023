using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BarrelLock : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] string rightCombination;
    [SerializeField] List<char> currCombination = new List<char>();
    [SerializeField] int Index = 0;
    bool directionRight = false;
    [SerializeField] float lerpSpeed = 1;
    [SerializeField] UnityEvent onRightCombination;

    public void RotateRight()
    {
        if (!directionRight) AddComb();
        directionRight = true;
        Index = (Index + 1) % 6;
        if (Index >= 0) currCombination[0] = Index.ToString()[0];
        else currCombination[0] = (6 + Index).ToString()[0];
        CheckCommb();
    }
    public void RotateLeft()
    {
        if (directionRight) AddComb();
        directionRight = false;
        Index = (Index - 1) % 6;
        if (Index >= 0) currCombination[0] = Index.ToString()[0];
        else currCombination[0] = (6 - Index).ToString()[0];
        CheckCommb();
    }

    public void CheckCommb()
    {
        for (int i = 0; i < currCombination.Count; i++) if (currCombination[i] != rightCombination[i]) return;
        onRightCombination.Invoke();
    }

    [Button]
    void AddComb()
    {
        currCombination.RemoveAt(1);
        if (Index >= 0)
        {
            currCombination.Add(Index.ToString()[0]);
        }
        else
        {
            currCombination.Add((6 + Index).ToString()[0]);
        }
    }

    private void Update()
    {
        barrel.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(barrel.transform.eulerAngles.z, -Index * 60, Time.deltaTime * lerpSpeed));
    }
}
