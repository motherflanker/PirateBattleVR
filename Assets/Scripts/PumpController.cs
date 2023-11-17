using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________���������_��������_������______________________________________
public class PumpController : MonoBehaviour
{
    public GameObject ball; // ������ �� ���, ������� ����� ��������
    public Transform handle; // ������ �� ����� ������
    public Transform tube; // ������ �� ����� ������
    public float pumpSpeed = 1f; // �������� �������
    public float minHandleHeight = 0f; // ����������� ������ �����
    public float maxHandleHeight = 1f; // ������������ ������ �����

    private float handleHaight = 0f;
    private float currentScale = 0f; // ������� ������� ����

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
