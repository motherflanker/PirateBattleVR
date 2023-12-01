using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpController : MonoBehaviour
{
    public GameObject ball;
    public Transform handle;
    public Transform tube;
    public float pumpSpeed = 1f;
    public float minHandleHeight = 0f;
    public float maxHandleHeight = 1f;

    private float handleHeight = 0f;
    private float currentScale = 0f;

    private void Update()
    {
        if (handle.transform.position.y > maxHandleHeight & handle.transform.position.x > 0 & handle.transform.position.z > 0)
            handle.transform.position = new Vector3(0, maxHandleHeight, 0);
        handleHeight = Mathf.Clamp(handle.localPosition.y, minHandleHeight, maxHandleHeight);
        //handle.localPosition = new Vector3(handle.localPosition.x, handleHeight, handle.localPosition.z);

        if (handleHeight == maxHandleHeight)
        {
            if (ball != null)
            {
                PumpBall();
            }
        }
    }

    private void PumpBall()
    {
        float pumpAmount = (handleHeight - minHandleHeight) / (maxHandleHeight - minHandleHeight);
        currentScale += pumpAmount * pumpSpeed * Time.deltaTime;
        ball.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}