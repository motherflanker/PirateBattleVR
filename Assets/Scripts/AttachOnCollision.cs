using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//______________________________ПРИКРЕПЛЕНИЕ_ОБЪЕКТА_К_ДРУГОМУ ОБЪЕКТУ______________________________________
//скрипт находится на прикрепляемом объекте
public class AttachOnCollision : MonoBehaviour
{
    public PumpController pumpController;
    private bool isAttached = false;
    private void OnCollisionEnter(Collision collision)
    {
        void Start()
        {
            //получение ссылки на класс PumpController
            pumpController = GetComponent<PumpController>();

        }
        if (!isAttached && collision.gameObject.CompareTag("AttachObject"))
        { 
            //присвоение переменной шар в скрипте насоса ссыки на шар
            pumpController.ball = gameObject;
            // Получаем Rigidbody обоих объектов
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Прикрепляем объект к другому объекту
            //rigidbody.isKinematic = true;
            transform.parent = collision.transform;

            // Если нужно, можно также передвинуть объект в определенную позицию относительно другого объекта
            //transform.localPosition = new Vector3(0, 0, 0);

            // Если нужно, можно также повернуть объект относительно другого объекта
            //transform.localRotation = Quaternion.identity;

            //!!!!пусть это пока что будет отключено, а то шар летает!!!!
            // Отключаем коллайдер объекта, чтобы избежать дальнейших соприкосновений
            //GetComponent<Collider>().enabled = false;

            //!!!!пусть это пока что будет отключено, а то шар летает!!!!
            // Отключаем Rigidbody другого объекта, чтобы избежать физического взаимодействия
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