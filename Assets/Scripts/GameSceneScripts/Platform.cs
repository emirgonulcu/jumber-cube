using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Platform : MonoBehaviour
{
    public float jump_strenght;
    public bool IsEnterPlatform;

    int double_jump_chance;

    float random_value;
    static float scoreControl;

    public Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        double_jump_chance = Random.Range(1, 11);
        Time.timeScale = 1f;

        scoreControl = 100f;
        if (double_jump_chance == 1)
        {
            anim.SetBool("IsDoubleJump", true);
            jump_strenght = 20f;
        }
        else
        {
            jump_strenght = 14f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 jump_velocity = rb.velocity;
                jump_velocity.y = jump_strenght;
                rb.velocity = jump_velocity;

                if (IsEnterPlatform == false)
                {
                    random_value = Random.Range(1, 6);
                    GameManager.score+=random_value;
                    IsEnterPlatform = true;
                    
                }

                if (IsEnterPlatform==true)
                {
                    bool v = GameManager.score > scoreControl;
                    if (v)
                    {
                        Time.timeScale = Time.timeScale + 0.07f;
                        scoreControl = scoreControl + 100;
                        Debug.Log("ScoreControl = " + scoreControl + " Score = " + GameManager.score + " Bool = " + v);
                    }
                }
                anim.SetBool("IsEnterPlatform", true);
                Destroy(gameObject, 1.5f);
            }
        }
       
    }

}
