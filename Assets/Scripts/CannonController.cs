using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab; // ������ ����
    public Transform spawnPoint; // ����� ��������� �����
    public float shootInterval = 0.01f; // �������� ����� ����������


    public float rotationSpeed = 60f; // �������� �������� �������
    float smooth = 5.0f;
    private float currentRotation = 180f; // ������� ���� �������� �������
    private int rotationDirection = 1; // ����������� �������� ������� (1 - �����, -1 - ������)



    private void Start()
    {
        // ��������� �������� ��� �������������� ��������
        StartCoroutine(ShootCoroutine());
    }

    private void Update()
    {
        // ������������ ������ ����� ��� ������
        float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;
        currentRotation += rotationAmount;

        // ������������ ���� ��������
        currentRotation = Mathf.Clamp(currentRotation, 60f, 180f);

        // ��������� ������� �������
        transform.rotation = Quaternion.Euler(-90f, currentRotation, 0f);
         //= Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        // ���� ��������� ������������ ���� ��������, ������ ����������� ��������
        if (Mathf.Abs(currentRotation) >= 180f || Mathf.Abs(currentRotation) <= 60f)
        {
            rotationDirection *= -1;
        }
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            // ������� ��������� ���� �� ������� � ������ ��� ��������� � �����������
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            ball.tag = "clone";
            //������ �� ���������� ����
            ballController ballController = ball.AddComponent<ballController>();


            // ��������� ��� ������
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(spawnPoint.forward * 10f, ForceMode.Impulse);
        }
    }
}