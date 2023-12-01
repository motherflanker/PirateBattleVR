using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{

    void Update()
    {
        if (gameObject.tag == "clone")
        {
            Destroy(gameObject, 5);
        }
    }
}
