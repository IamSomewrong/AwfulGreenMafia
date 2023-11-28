using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5;
    GameObject _player;
    Rigidbody2D _rb;
    private bool _flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < 10 && Vector3.Distance(gameObject.transform.position, _player.transform.position) > 5 && Mathf.Abs(gameObject.transform.position.y - _player.transform.position.y) <= 2)
        {
            if(_player.transform.position.x > transform.position.x)
            {
                if (_flipped)
                {
                    Flip();
                }
                _rb.velocity = new Vector2(speed, _rb.velocity.y);
            }
            else
            {
                if (!_flipped)
                {
                    Flip();
                }
                _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            }
        }
    }

    void Flip()
    {
        _flipped = !_flipped;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
