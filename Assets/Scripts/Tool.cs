using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tool", menuName = "Objects/Tool")]
public class Tool : ScriptableObject
{
    public Sprite sprite;
    public AnimationClip animClip;
    public int hitDamage;
    public int thrownDamage;
    public int durability;

    public void Copy(Tool tool)
    {
        sprite = tool.sprite;
        animClip = tool.animClip;
        hitDamage = tool.hitDamage;
        thrownDamage = tool.thrownDamage;
        durability = tool.durability;
    }
}
