using System.Collections;
using UnityEngine;

public class TimeTravelBehaviour : MonoBehaviour
{
    [SerializeField] KeyCode timeTravelKey;
    [SerializeField] GameObject timeTravelCamera;
    float cooldownTime = 0.5f;
    bool onCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator timeTravel()
    {
        if (timeTravelCamera == null) yield break;

        if (timeTravelCamera.activeInHierarchy) timeTravelCamera.SetActive(false);
        else timeTravelCamera.SetActive(true);

        onCooldown = true;
        yield return cooldownTime;
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
