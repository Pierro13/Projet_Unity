using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints = new List<Transform>();
    private Transform _currentTarget;
    public static bool isComplete;

    private void Start()
    {
        // Initialize the first checkpoint as the current target
        if (checkpoints.Count > 0)
        {
            isComplete = false;
            _currentTarget = checkpoints[0];
            _currentTarget.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (_currentTarget != null)
        {
            // Rotate the arrow to point towards the current target
            transform.LookAt(_currentTarget);
        }
    }
    
    public Transform GetCurrentTarget()
    {
        return _currentTarget;
    }
    
    public void SetCheckpoints(List<Transform> newCheckpoints)
    {
        checkpoints = newCheckpoints;
        if (checkpoints.Count > 0)
        {
            _currentTarget = checkpoints[0];
            isComplete = false;
            _currentTarget.gameObject.SetActive(true);
        }
    }
    
    public void SetNextTarget()
    {
        int currentIndex = checkpoints.IndexOf(_currentTarget);
        int nextIndex = currentIndex + 1;

        if (nextIndex < checkpoints.Count)
        {
            _currentTarget.gameObject.SetActive(false);
            _currentTarget = checkpoints[nextIndex];
            _currentTarget.gameObject.SetActive(true);
        }
        else
        {
            _currentTarget = null;
            isComplete = true;
            gameObject.SetActive(false);
        }
    }
}

