using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallSpawner : MonoBehaviour
{
    public GameObject bullet;
    public GameObject notch;
    private bool _ballNotched = false;
    private GameObject _currentBall = null;

    void Start()
    {
        PullInteraction.PullActionReleased += NotchEmpty;    
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= NotchEmpty;
    }

    //the Update needs to be gone as well cuz attachment is not a runtime task
    //the code inside current update function should still work
    private void Update()
    {
        if(_ballNotched == false)
        {
            _ballNotched = true;
            //create and call new method for attaching grabbable object instead of coroutine
            StartCoroutine("DelayedSpawn");
        }
        if(_currentBall == null) 
        {
            Destroy(_currentBall);
            NotchEmpty(1f);
        }
    }

    private void NotchEmpty(float value)
    {
        _currentBall = null;
        _ballNotched = false;
    }

    //no need for enumerator cuz it doesnt need to do calls step by step => switch it with a normal method
    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1f);
        _currentBall = Instantiate(bullet, notch.transform);
    }
}
