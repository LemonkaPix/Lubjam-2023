using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TimeTravelBehaviour : MonoBehaviour
{
    [SerializeField] KeyCode timeTravelKey;
    [SerializeField] GameObject[] urpObjects;
    [SerializeField] GameObject[] cameras;
    [SerializeField] TextMeshProUGUI YearText;
    public bool playerHasWatch = false;
    bool tpCooldown = false;
    bool onCooldown = false;
    bool isFuture = false;



    IEnumerator yearTextAnim()
    {
        if (urpObjects[0].activeInHierarchy)
        {
            for (int i = 1; i < 67; i++)
            {
                YearText.text = $"Year {2023 - i}";
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            for (int i = 1; i < 67; i++)
            {
                YearText.text = $"Year {1956 + i}";
                yield return new WaitForSeconds(0.01f);
            }
        }
    }


    IEnumerator timeTravel()
    {
        onCooldown = true;

        GameObject screenFlash = Instantiate(urpObjects[2], YearText.transform.parent);
        screenFlash.transform.SetAsFirstSibling();
        Image imageColor = screenFlash.GetComponent<Image>();


        // Year text anim
        StartCoroutine(yearTextAnim());

        yield return new WaitUntil(() => imageColor.color.a == 1);
        transform.position = new Vector3(transform.position.x, transform.position.y + (isFuture ? -500 : 500), transform.position.z);
        // Teleporting player to past


        // Changing camera effects
        urpObjects[0].SetActive(isFuture);
        urpObjects[1].SetActive(!isFuture);
        cameras[0].SetActive(isFuture);
        cameras[1].SetActive(!isFuture);
        yield return new WaitUntil(() => imageColor.color.a == 0);
        Destroy(screenFlash);
        isFuture = !isFuture;
        onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(timeTravelKey) && !onCooldown)
        {
            Debug.Log("Time travel");


            StartCoroutine(timeTravel());
        }
    }
}
