using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeLock : MonoBehaviour
{

    [SerializeField] Color[] combinations;
    [SerializeField] GameObject sprite;
    public Color currentColor;
    int currentIndex;
    ColorLock colorLock;


    private void Start()
    {
        colorLock = gameObject.transform.parent.GetComponent<ColorLock>();
    }


    void OnMouseDown()
    {
        if (currentIndex > combinations.Length - 1) currentIndex = 0;

        sprite.GetComponent<SpriteRenderer>().color = combinations[currentIndex];
        currentColor = combinations[currentIndex];
        currentIndex++;

        colorLock.CheckCombination();
    }



}
