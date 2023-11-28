using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Block;
    private GameObject[] _rooms = new GameObject[10];

    private void Start()
    {
        for (int i = 0; i < _rooms.Length; i++)
        {
            Vector2 pos = GetRandomPointInCircle(50);
            GameObject roomObject = Instantiate(new GameObject(), new Vector3(pos.x, pos.y), Quaternion.identity);
            Room room = roomObject.AddComponent<Room>();
            room.Id = i;
            room.Position = new Vector2(pos.x, pos.y);
            room.Width = (Random.Range(10, 40) + Random.Range(10, 40) + Random.Range(10, 40)) / 3;
            room.Height = (Random.Range(10, 40) + Random.Range(10, 40) + Random.Range(10, 40)) / 3;
            room.gameObjects = new GameObject[room.Width, room.Height];
            room.MakeWalls(Block);
        }
    }

    private Vector2 GetRandomPointInCircle(int radius)
    {
        float t = 2 * Mathf.PI * Random.Range(0f, 1f);
        float u = Random.Range(0f, 1f) + Random.Range(0f, 1f);
        float r;
        if (u > 1)
        {
            r = 2 - u;
        }
        else
        {
            r = u;
        }
        return new Vector2(radius * r * Mathf.Cos(t), radius * r * Mathf.Sin(t));
    }
}
