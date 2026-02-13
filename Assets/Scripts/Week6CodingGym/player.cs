using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float playerSpeed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition=transform.position;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            oldPosition.x -= playerSpeed*Time.deltaTime;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            oldPosition.x += playerSpeed * Time.deltaTime;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            oldPosition.y += playerSpeed * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            oldPosition.y -= playerSpeed * Time.deltaTime;
        }
        transform.position = oldPosition;
    }
}
