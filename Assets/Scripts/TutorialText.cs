using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] GameObject tutorialText;
   public void showTutorialText(string Text)
    {
        tutorialText.SetActive(false);
        tutorialText.GetComponent<TextMeshProUGUI>().text = Text;
        tutorialText.SetActive(true);
    }
}
