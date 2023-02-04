using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

enum selfTalkType
{
    None,
    Item,
    Door
}


public class OnClick : MonoBehaviour
{
    [Header("Mainx")]
    [SerializeField] UnityEvent onClick;
    [SerializeField] Transform player;
    [SerializeField] float distance;


    [Header("Self talk")]
    [SerializeField] bool canSelfTalk = false;
    [SerializeField] bool repeatSelfTalk = false;
    [SerializeField] selfTalkType selfTalkType = selfTalkType.None;
    [SerializeField] TextMeshProUGUI selfTalk;
    [SerializeField] string selfTalkText;
    [SerializeField] string doorLockedText;

    [Header("Optional")]
    [SerializeField] bool doorBarricaded = false;

    [SerializeField] UnityEvent tutorialTextPopUp;

    PlayerInventory plrInventory;

    private void Start()
    {
        plrInventory = FindObjectOfType<PlayerInventory>();
    }

    private void OnMouseDown()
        {
        if (EventSystem.current.IsPointerOverGameObject()) return;


        if (Vector3.Distance(player.position, transform.position) <= distance)
        {
            onClick.Invoke();

            if (tutorialTextPopUp != null) tutorialTextPopUp.Invoke();

            if (canSelfTalk)
            {

                if (selfTalkType == selfTalkType.Door)
                {
                    DoorAnimation doorScript = transform.GetComponent<DoorAnimation>();
                    if (doorScript.isLocked == false) return;

                    foreach (GameObject item in plrInventory.inventory)
                    {
                        if (item.GetComponent<ItemData>().itemId == doorScript.keyId)
                        {
                            plrInventory.inventory.Remove(item);
                            doorScript.isLocked = false;

                            selfTalk.gameObject.SetActive(false);

                            selfTalk.text = selfTalkText;
                            selfTalk.gameObject.SetActive(true);
                            break;
                        }

                        else if(item.GetComponent<ItemData>().itemType == ItemType.Crowbar && doorBarricaded)
                        {
                            doorScript.isLocked = false;

                            selfTalk.gameObject.SetActive(false);

                            selfTalk.text = selfTalkText;
                            selfTalk.gameObject.SetActive(true);

                            break;
                        }
                    }
                    if (doorScript.isLocked == true) 
                    {
                        selfTalk.gameObject.SetActive(false);

                        selfTalk.text = doorLockedText;
                        selfTalk.gameObject.SetActive(true);
                    };
                }

                else if (selfTalkType == selfTalkType.Item)
                {
                    if (!repeatSelfTalk) canSelfTalk = false;

                    selfTalk.gameObject.SetActive(false);

                    selfTalk.text = selfTalkText;
                    selfTalk.gameObject.SetActive(true);
                }
            }
        }
    }
}
