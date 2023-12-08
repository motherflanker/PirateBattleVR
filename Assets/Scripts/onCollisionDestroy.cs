using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class onCollisionDestroy : MonoBehaviour {

    
    public int count;
    public Text text;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            count++;
            text.text = count.ToString();
        }
    }

   
}
