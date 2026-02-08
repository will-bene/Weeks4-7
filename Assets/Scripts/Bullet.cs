using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public float missileSpeed = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity = transform.right * missileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration;
        transform.position += velocity * Time.deltaTime;
    }
}
