using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float reloadTime;
    public GameObject bullet;
    public float throwForce;
    public ParticleSystem destroyParticles;
    GameObject _player;
    bool _reloaded = true;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_reloaded && Vector3.Distance(gameObject.transform.position, _player.transform.position) < 10  && Mathf.Abs(gameObject.transform.position.y - _player.transform.position.y) < 2) 
        {
            if (_player.transform.position.x > transform.position.x)
            {
                GameObject someBullet = Instantiate(bullet, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                someBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForce, 200));
                DestroyThrownItem dti = someBullet.AddComponent<DestroyThrownItem>();
                dti.particles = destroyParticles;
            }
            else if (_player.transform.position.x < transform.position.x)
            {
                GameObject someBullet = Instantiate(bullet, transform.position + new Vector3(-2, 0, 0), Quaternion.identity);
                someBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-throwForce, 200));
                DestroyThrownItem dti = someBullet.AddComponent<DestroyThrownItem>();
                dti.particles = destroyParticles;
            }
            _reloaded = false;
            StartCoroutine(nameof(Reload));
        }
    }

    IEnumerator Reload()
    {
        yield return  new WaitForSeconds(reloadTime);
        _reloaded = true;
    }
}
