using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // 따라갈 대상 오브젝트
    public float moveSpeed = 5.0f; // 이동 속도

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float distanceThisFrame = moveSpeed * Time.deltaTime;
            
            if (direction.magnitude <= distanceThisFrame)
            {
                transform.position = target.position;
            }
            else
            {
                transform.Translate(direction.normalized * distanceThisFrame);
            }
        }
    }
}
