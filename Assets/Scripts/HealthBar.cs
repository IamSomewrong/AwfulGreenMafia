using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider _rect;
    void Start()
    {
        _rect = GetComponent<Slider>();
        TakeDamage.hpchanged += ChangeHpBar;
    }

    void ChangeHpBar(int hp)
    {
        _rect.value = hp;
    }
}
