using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThrownItem : MonoBehaviour
{
    public ParticleSystem particles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage td;
        if (collision.gameObject.TryGetComponent(out td))
        {
            td.Damage(GetComponent<ToolScript>().tool.thrownDamage);
        }
        GetComponent<AudioSource>().Play();
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
