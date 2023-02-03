using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour
{
    [SerializeField] UnityEvent onClick;
    [SerializeField] Transform player;
    [SerializeField] float distance;


        private void OnMouseDown()
    {
        if (Vector3.Distance(player.position, transform.position) <= distance) onClick.Invoke();
    }
}
