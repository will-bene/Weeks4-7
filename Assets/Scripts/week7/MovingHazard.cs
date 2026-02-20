using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    public float speed;
    private float direction = 1f;
    public bool awake = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            transform.position += direction * transform.right * speed * Time.deltaTime;

            Vector2 screenPacerPosition = Camera.main.WorldToScreenPoint(transform.position);



            if (screenPacerPosition.x < 0 || screenPacerPosition.x > Screen.width)
            {
                direction *= -1;
            }
        }

    }

    public void Awake()
    {
        Debug.Log("awake");
        awake = true;
    }
}
