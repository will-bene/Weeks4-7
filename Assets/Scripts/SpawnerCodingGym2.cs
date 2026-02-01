using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SpawnerCodingGym2 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject me;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        bool isOverMouse = spriteRenderer.bounds.Contains(MousePosition);
        bool mouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (mouseClicked && isOverMouse)
        {
            Destroy(gameObject);
        }
    }
}
