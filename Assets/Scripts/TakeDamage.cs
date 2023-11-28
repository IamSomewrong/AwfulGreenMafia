using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TakeDamage : MonoBehaviour
{
    public int hp = 100;
    public ParticleSystem destroyParticles;
    private AudioSource _audio;
    public GameObject deathScreen;

    public static UnityAction<int> hpchanged;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void Damage(int damage)
    {
        hp -= damage;
        _audio.Play();
        if (gameObject.CompareTag("Player"))
        {
            hpchanged?.Invoke(hp);
        }
        if (hp <= 0)
        {
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                deathScreen.SetActive(true);
            }
        }
    }
}
