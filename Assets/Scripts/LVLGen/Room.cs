using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Room: MonoBehaviour
{
    public int Id { get; set; }
    public Vector2 Position { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public GameObject[,] gameObjects;


    public void MakeWalls(GameObject wall)
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if(i == Width - 1 || i == 0 || j == Height - 1 || j == 0)
                {
                    gameObjects[i, j] = Instantiate(wall, new Vector3(i + Position.x - Width/2, j + Position.y - Height/2, 0), Quaternion.identity, transform);
                }
            }
        }
        gameObject.AddComponent<BoxCollider2D>().size = new Vector2(Width, Height);
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
    }
}
