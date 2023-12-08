using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratesAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("enemy")) {
            GameObject pirateMusic = GameObject.FindGameObjectWithTag("piratesMusic");
            Destroy(pirateMusic);
        } 
    }
}
