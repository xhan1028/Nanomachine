using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMent : MonoBehaviour
{
    public float maxSpeed;
    public AudioSource moveSoundClip; 
    private Rigidbody2D rigid;
    SpriteRenderer rend;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveSoundClip = GetComponent<AudioSource>();

        if (moveSoundClip == null)
        {
            moveSoundClip = gameObject.AddComponent<AudioSource>();
        }
    } 
    

    void Update()
    {
        // 문워크 방지
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        // Flip
        if (Input.GetButtonDown("Horizontal"))
        {
            rend.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        // 애니메이션
      //  if (Mathf.Abs(rigid.velocity.x) < 0.3)
       // {
     //       anim.SetBool("IsWalk", false);
     //   }
      //  else
       // {
        //    anim.SetBool("IsWalk", true);
       // }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) // 오른쪽 최고 속도
        { 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // 왼쪽 최고 속도
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // 이동 속도에 따라 오디오 재생
        if (Mathf.Abs(rigid.velocity.x) > 0.1f && !moveSoundClip.isPlaying)
        {
            moveSoundClip.Play();
        }
        else if (Mathf.Abs(rigid.velocity.x) < 0.1f && moveSoundClip.isPlaying)
        {
            moveSoundClip.Stop();
        }
    }
}