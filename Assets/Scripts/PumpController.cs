using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________ОСНОВНАЫЕ_МЕХАНИКИ_НАСОСА______________________________________
public class PumpController : MonoBehaviour
{
    public GameObject ball; // Ссылка на шар, который нужно накачать
    public Transform handle; // Ссылка на ручку насоса
    public Transform tube; // Ссылка на шланг насоса
    public float pumpSpeed = 1f; // Скорость накачки
    public float minHandleHeight = 0f; // Минимальная высота ручки
    public float maxHandleHeight = 1f; // Максимальная высота ручки

    private float handleHaight = 0f;
    private float currentScale = 0f; // Текущий масштаб шара

    private void Update()
    {
        handleHaight = handle.localPosition.y;
        Physics.IgnoreCollision(tube.GetComponent<Collider>(), GetComponent<Collider>());
        if (handleHaight == maxHandleHeight)
        {
            if (ball != null)
            {
                PumpBall();
            }
                
        }
    }

    private void PumpBall()
    {
        float handleHeight = Mathf.Clamp(handle.localPosition.y, minHandleHeight, maxHandleHeight);
        float pumpAmount = (handleHeight - minHandleHeight) / (maxHandleHeight - minHandleHeight);
        currentScale += pumpAmount * pumpSpeed * Time.deltaTime;
        ball.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    /*
     private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 handlePosition = handle.localPosition;
            handlePosition.y += mouseY;
            handle.localPosition = handlePosition;
        }
         if (ball!=null) PumpBall();
    }
     */


}
