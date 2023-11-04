using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________����������_�����______________________________________
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
        // ���������� �������� ����� �������� ������� � �������� �������
        offset = gameObject.transform.position - GetMouseWorldPosition();

        // �������� ������ ��� ���������������
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // ��������, ��� ������ ������ �� ���������������
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // ��������� ������� ������� � ������������ � �������� �������
            gameObject.transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}ssss

 */