using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed;
    private float horizontal_move;

    public GameManager manager;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        horizontal_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal_move*speed*Time.deltaTime, rb.velocity.y);

        Vector2 newScale = transform.localScale;

        if (horizontal_move > 0)
        {
            newScale.x = 0.2f;
        }
        if (horizontal_move < 0)
        {
            newScale.x = -0.2f;
        }

        transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeathArea")
        {
            Time.timeScale = 1f;
            manager.GameOver();
        }
    }
}
