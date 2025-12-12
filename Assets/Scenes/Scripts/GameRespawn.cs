using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public Vector3 spawnPoint;

    void Update()
    {
        if (transform.position.y < threshold)
        { transform.position = new Vector3(0.35355f, 1.84f, 0.35355f);
            GameManager.health -= 1;
        }


    }
}
