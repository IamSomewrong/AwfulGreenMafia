using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandTool : MonoBehaviour
{
    public Tool tool;
    public GameObject someBullet;
    private GameObject _tempTool;
    public ParticleSystem destroyParticles;
    private bool _toolInRange = false;
    private bool _medicines = false;
    private bool _win = false;
    private GameObject _medObj;
    private Animation _anim;
    private SpriteRenderer _sprite;
    private PlayerMove _playerMove;
    public float throwForce;
    public GameObject menu;

    private void Start()
    {
        _anim = GetComponent<Animation>();
        _sprite = GetComponent<SpriteRenderer>();
        _playerMove = GetComponentInParent<PlayerMove>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<TakeDamage>().Damage(tool.hitDamage);
            tool.durability -= 1;
            if(tool.durability <= 0)
            {
                tool = null;
                _sprite.sprite = null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tool"))
        {
            _toolInRange = true;
            _tempTool = collision.gameObject;
        }
        if (collision.CompareTag("Medicine"))
        {
            _medicines = true;
            _medObj = collision.gameObject;
        }
        if (collision.CompareTag("Exit"))
        {
            _win = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tool"))
        {
            _toolInRange = false;
            _tempTool = null;
        }
        if (collision.CompareTag("Medicine"))
        {
            _medicines = false;
            _medObj = null;
        }
        if (collision.CompareTag("Exit"))
        {
            _win = false;
        }
    }


    private void Update()
    {
        if (_toolInRange && tool == null && Input.GetKeyDown(KeyCode.E))
        {
            tool = ScriptableObject.CreateInstance<Tool>();
            tool.Copy(_tempTool.GetComponent<ToolScript>().tool);
            _sprite.sprite = tool.sprite;
            _anim.clip = tool.animClip;
            Destroy(_tempTool);
        }

        if(tool != null && Input.GetKey(KeyCode.Mouse0))
        {
            _anim.Play();
            
        }

        if (tool != null && Input.GetKey(KeyCode.Mouse1))
        {
            GameObject bullet = Instantiate(someBullet, _playerMove.fliped? transform.position + new Vector3(-2, 0, 0): transform.position + new Vector3(2, 0, 0), Quaternion.identity);
            bullet.GetComponent<ToolScript>().tool = tool;
            bullet.GetComponent<Rigidbody2D>().AddForce(_playerMove.fliped ? new Vector2(-throwForce, 200) : new Vector2(throwForce, 200));
            DestroyThrownItem dti = bullet.AddComponent<DestroyThrownItem>();
            dti.particles = destroyParticles;
            tool = null;
            _sprite.sprite = null;
        }

        if (_medicines && Input.GetKeyDown(KeyCode.E))
        {
            GetComponentInParent<TakeDamage>().hp = 125;
            TakeDamage.hpchanged.Invoke(GetComponentInParent<TakeDamage>().hp);
            Destroy(_medObj);
        }

        if(_win && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent.position = new Vector3(-52, 22, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}

