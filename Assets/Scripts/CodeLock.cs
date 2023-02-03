using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeLock : MonoBehaviour
{
    [SerializeField] UnityEvent onRightCombination;
    [SerializeField] LockNum[] nums;
    [SerializeField] string rightCombination;

    public void CheckCombination()
    {
        bool isRight = true;
        for (int i = 0; i < nums.Length; i++) if (nums[i].combValue != rightCombination[i]) return;
        if (isRight) onRightCombination.Invoke();
    }
}
