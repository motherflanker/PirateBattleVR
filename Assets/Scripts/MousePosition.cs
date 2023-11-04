using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________УПРАВЛЕНИЕ_МЫШЬЮ______________________________________
public class MousePosition : MonoBehaviour
{
    public float speed = 1;
    void FixedUpdate()
    {
        Vector3 mouse = new Vector3(Input.GetAxis("Mouse X") * speed * Time.deltaTime, Input.GetAxis("Mouse Y") * speed * Time.deltaTime, 0);
        transform.Translate(mouse * speed);
     }
}

/*
 
{
    private bool isDragging = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        // Запоминаем смещение между позицией объекта и позицией курсора
        offset = gameObject.transform.position - GetMouseWorldPosition();

        // Помечаем объект как перетаскиваемый
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // Отмечаем, что объект больше не перетаскивается
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // Обновляем позицию объекта в соответствии с позицией курсора
            gameObject.transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}ssss

 */