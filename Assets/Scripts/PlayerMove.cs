using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpHeight = 10.0f;
    public bool fliped = false;
    private bool _jumping = false;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(move * speed, _rigidbody.velocity.y);
        if (!_jumping && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (!fliped && move < 0)
        {
            Flip();
        }
        if(fliped && move > 0)
        {
            Flip();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _jumping = false;
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        fliped = !fliped;
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, jumpHeight));
        _jumping = true;
    }
}
