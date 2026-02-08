using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    public float moveSpeed;
    Camera gameCamera = Camera.main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool leftKeyPressed = Keyboard.current.leftArrowKey.isPressed;
        if (leftKeyPressed)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        bool rightKeyPressed = Keyboard.current.rightArrowKey.isPressed;
        if (rightKeyPressed)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        float screenMin = 0;
        float screenMax = Screen.width;
        Vector3 worldPosition = gameCamera.WorldToScreenPoint(transform.position);



    }
}
