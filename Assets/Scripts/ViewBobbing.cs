using UnityEngine;
using System.Collections;

public class ViewBobbing : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float Speed;
    [SerializeField] bool IsFullWave = true;
    [SerializeField] Vector3 Amount;

    private float timer = 0.0f;
    public void Update()
    {
        var position = transform.localPosition;
        if (!playerController.playerIsMoving)
        {
            if (timer == 0 || Mathf.Abs(timer - Mathf.PI) < 0.01)
            {
                return;
            }
        }

        float moveCyclePercent = Mathf.Sin(timer);
        timer += Speed;

        if (timer > Mathf.PI * (IsFullWave ? 2 : 1))
        {
            timer = 0.0f;
        }

        if (Amount.x != 0)
        {
            position.x = Amount.x * moveCyclePercent;
        }

        if (Amount.y != 0)
        {
            position.y = Amount.y * moveCyclePercent + 0.6f;
        }

        if (Amount.z != 0)
        {
            position.z = Amount.z * moveCyclePercent;
        }

        transform.localPosition = position;
    }
}