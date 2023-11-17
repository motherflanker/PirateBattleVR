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