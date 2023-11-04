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
            // �������� Rigidbody ����� ��������
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // ����������� ������ � ������� �������
            //rigidbody.isKinematic = true;
            transform.parent = collision.transform;

            // ���� �����, ����� ����� ����������� ������ � ������������ ������� ������������ ������� �������
            //transform.localPosition = new Vector3(0, 0, 0);

            // ���� �����, ����� ����� ��������� ������ ������������ ������� �������
            //transform.localRotation = Quaternion.identity;

            //!!!!����� ��� ���� ��� ����� ���������, � �� ��� ������!!!!
            // ��������� ��������� �������, ����� �������� ���������� ���������������
            //GetComponent<Collider>().enabled = false;

            //!!!!����� ��� ���� ��� ����� ���������, � �� ��� ������!!!!
            // ��������� Rigidbody ������� �������, ����� �������� ����������� ��������������
            //otherRigidbody.isKinematic = true;

            isAttached = true;
        }
        else
        {
            isAttached = false;
            pumpController.ball = null;
        }
    }
}