using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{

    public GameObject letterObject;
    [SerializeField] GameObject letterButton;

    public void showLetter()
    {
        letterObject.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(showLetterWait());
    }

    IEnumerator showLetterWait()
    {

        letterButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        letterButton.GetComponent<Button>().enabled = true;
    }    

    public void hideLetter()
    {
        letterObject.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
