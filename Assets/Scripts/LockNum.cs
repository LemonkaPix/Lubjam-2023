using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockNum : MonoBehaviour
{
    CodeLock codeLock;
    [SerializeField] string combination;
    [SerializeField] TMP_Text text;
    int combinationIndex = 0;
    public int combValue;

 

    private void Start()
    {
        codeLock = gameObject.transform.parent.GetComponent<CodeLock>();
        text.text = $"{combination[combinationIndex]}\n";
    }

    private void OnMouseDown()
    {
        Change();
    }

    public void Change()
    {
        combinationIndex = (combinationIndex + 1) % combination.Length;

        text.text = $"{combination[combinationIndex]}\n";

        combValue = combination[combinationIndex];

        codeLock.CheckCombination();
    }
}
