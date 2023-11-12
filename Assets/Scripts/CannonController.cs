using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab; // Префаб шара
    public Transform spawnPoint; // Точка появления шаров
    public float shootInterval = 2f; // Интервал между выстрелами


    public float rotationSpeed = 30f; // Скорость поворота объекта

    private float currentRotation = 0f; // Текущий угол поворота объекта
    private int rotationDirection = 1; // Направление поворота объекта (1 - влево, -1 - вправо)

    private void Start()
    {
        // Запускаем корутину для автоматической стрельбы
        StartCoroutine(ShootCoroutine());
    }

    private void Update()
    {
        // Поворачиваем объект влево или вправо
        float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;
        currentRotation += rotationAmount;

        // Ограничиваем угол поворота
        currentRotation = Mathf.Clamp(currentRotation, -180f, 180f);

        // Применяем поворот объекта
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

        // Если достигнут максимальный угол поворота, меняем направление поворота
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

            // Создаем экземпляр шара из префаба и задаем его положение и направление
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

            // Запускаем шар вперед
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(spawnPoint.forward * 10f, ForceMode.Impulse);
        }
    }
}