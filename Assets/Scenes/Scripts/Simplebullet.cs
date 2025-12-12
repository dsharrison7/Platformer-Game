
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
