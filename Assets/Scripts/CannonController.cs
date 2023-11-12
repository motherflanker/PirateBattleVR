using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab; // ������ ����
    public Transform spawnPoint; // ����� ��������� �����
    public float shootInterval = 2f; // �������� ����� ����������


    public float rotationSpeed = 30f; // �������� �������� �������

    private float currentRotation = 0f; // ������� ���� �������� �������
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
        currentRotation = Mathf.Clamp(currentRotation, -180f, 180f);

        // ��������� ������� �������
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

        // ���� ��������� ������������ ���� ��������, ������ ����������� ��������
        if (Mathf.Abs(currentRotation) >= 180f)
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

            // ��������� ��� ������
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(spawnPoint.forward * 10f, ForceMode.Impulse);
        }
    }
}