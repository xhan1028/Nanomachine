using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMent : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        
        transform.position = newPosition;
    }
}