using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
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

    private void Update()
    {
        if(_ballNotched == false)
        {
            _ballNotched = true;
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

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1f);
        _currentBall = Instantiate(ball, notch.transform);
    }
}
