using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________������������_�������_�_������� �������______________________________________
//������ ��������� �� ������������� �������
public class AttachOnCollision : MonoBehaviour
{
    public PumpController pumpController;
    private bool isAttached = false;
    private void OnCollisionEnter(Collision collision)
    {
        void Start()
        {
            //��������� ������ �� ����� PumpController
            pumpController = GetComponent<PumpController>();

        }
        if (!isAttached && collision.gameObject.CompareTag("AttachObject"))
        { 
            //���������� ���������� ��� � ������� ������ ����� �� ���
            pumpController.ball = gameObject;
            //transform.parent = collision.transform;
            Physics.IgnoreCollision(pumpController.ball.GetComponent<Collider>(), GetComponent<Collider>());
            isAttached = true;
        }
        else
        {
            isAttached = false;
            pumpController.ball = null;
        }
    }
}