using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private List<Transform> checkpoints = new List<Transform>();
    
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        /*foreach(Transform checkpoint in checkpoints)
        {
            if (checkpoint.GetComponent<MeshRenderer>().material.color != Color.green)
            {
                target = checkpoint;
                break;
            }
        }*/
        //Vector3 targetPosition = target.transform.position;
        //targetPosition.y = transform.position.y;
        transform.LookAt(target);
    }
}
