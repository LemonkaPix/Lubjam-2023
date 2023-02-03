using System.Collections;
using UnityEngine;

public class TimeTravelBehaviour : MonoBehaviour
{
    [SerializeField] KeyCode timeTravelKey;
    [SerializeField] GameObject[] urpObjects;
    public bool playerHasWatch = false;
    float cooldownTime = 3f;
    bool onCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator timeTravel()
    {
        if (urpObjects[0].activeInHierarchy)
        {
            urpObjects[0].SetActive(false);
            urpObjects[1].SetActive(true);
        }
        else
        {
            urpObjects[0].SetActive(true);
            urpObjects[1].SetActive(false);
        }

        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(timeTravelKey) && !onCooldown) 
        {
            Debug.Log("Time travel");
            StartCoroutine(timeTravel());
        }
    }
}
