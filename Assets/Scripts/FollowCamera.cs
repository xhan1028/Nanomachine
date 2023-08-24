using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float min;

    public float max;

    private void LateUpdate()
    {
        var targetPos = new Vector3(Mathf.Clamp(target.position, min, max));
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2);
    }
}
