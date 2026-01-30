using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float speed;
    private float direction = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * transform.right * speed * Time.deltaTime;

        Vector2 screenPacerPosition = Camera.main.WorldToScreenPoint(transform.position);



        if (screenPacerPosition.x<0 || screenPacerPosition.x>Screen.width)
        {
            direction *= -1;
        }

    }
}
