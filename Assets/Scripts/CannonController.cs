using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab; // Префаб шара
    public Transform spawnPoint; // Точка появления шаров
    public float shootInterval = 0.01f; // Интервал между выстрелами


    public float rotationSpeed = 60f; // Скорость поворота объекта
    float smooth = 5.0f;
    private float currentRotation = 180f; // Текущий угол поворота объекта
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
        currentRotation = Mathf.Clamp(currentRotation, 60f, 180f);

        // Применяем поворот объекта
        transform.rotation = Quaternion.Euler(-90f, currentRotation, 0f);
         //= Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        // Если достигнут максимальный угол поворота, меняем направление поворота
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

            // Создаем экземпляр шара из префаба и задаем его положение и направление
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            ball.tag = "clone";
            //ссылка на контроллер шара
            ballController ballController = ball.AddComponent<ballController>();


            // Запускаем шар вперед
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(spawnPoint.forward * 10f, ForceMode.Impulse);
        }
    }
}