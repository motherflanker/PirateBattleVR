using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________ОСНОВНАЫЕ_МЕХАНИКИ_НАСОСА______________________________________
public class PumpController : MonoBehaviour
{
    public GameObject ball; // Ссылка на шар, который нужно накачать
    public Transform handle; // Ссылка на ручку насоса
    public float pumpSpeed = 1f; // Скорость накачки
    public float minHandleHeight = 0f; // Минимальная высота ручки
    public float maxHandleHeight = 1f; // Максимальная высота ручки

    private bool isPumping = false; // Флаг, указывающий, что насос активен
    private float currentScale = 0f; // Текущий масштаб шара

    private void Update()
    {
        
    }

    private void PumpBall()
    {
        float handleHeight = Mathf.Clamp(handle.localPosition.y, minHandleHeight, maxHandleHeight);
        float pumpAmount = (handleHeight - minHandleHeight) / (maxHandleHeight - minHandleHeight);
        currentScale += pumpAmount * pumpSpeed * Time.deltaTime;
        ball.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 handlePosition = handle.localPosition;
            //если ручка в моменте уже находится выше корпуса насоса, но все еще ниже максимально допустимой высоты, 
            // то ее можно задрать куда угодно???
            /*
             if (handlePosition.y >= maxHandleHeight)
            handlePosition.y = maxHandleHeight;
            else
            handlePosition.y += mouseY;
             */
            //Возможно максимальная высота не работает только из-за скрипта управления мышью
            handlePosition.y += mouseY;
            handle.localPosition = handlePosition;
        }
         if (ball!=null) PumpBall();
    }
}
