using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________���������_��������_������______________________________________
public class PumpController : MonoBehaviour
{
    public GameObject ball; // ������ �� ���, ������� ����� ��������
    public Transform handle; // ������ �� ����� ������
    public float pumpSpeed = 1f; // �������� �������
    public float minHandleHeight = 0f; // ����������� ������ �����
    public float maxHandleHeight = 1f; // ������������ ������ �����

    private bool isPumping = false; // ����, �����������, ��� ����� �������
    private float currentScale = 0f; // ������� ������� ����

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
            //���� ����� � ������� ��� ��������� ���� ������� ������, �� ��� ��� ���� ����������� ���������� ������, 
            // �� �� ����� ������� ���� ������???
            /*
             if (handlePosition.y >= maxHandleHeight)
            handlePosition.y = maxHandleHeight;
            else
            handlePosition.y += mouseY;
             */
            //�������� ������������ ������ �� �������� ������ ��-�� ������� ���������� �����
            handlePosition.y += mouseY;
            handle.localPosition = handlePosition;
        }
         if (ball!=null) PumpBall();
    }
}
