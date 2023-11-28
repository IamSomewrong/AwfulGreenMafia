using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
