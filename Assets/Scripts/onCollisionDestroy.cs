using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class onCollisionDestroy : MonoBehaviour {

    
    public Text text;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            text.text += "●";
        }
    }

   
}
