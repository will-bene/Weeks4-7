using UnityEngine;
using UnityEngine.InputSystem;

public class knife : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject myBarrel;
    public barrel barrelScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        barrelScript = myBarrel.GetComponent<barrel>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        bool mousedOver = sr.bounds.Contains(mousePos);
        if (mousedOver)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {//clicked
                Debug.Log("mouse clicked on knife");
                if (myBarrel.activeSelf)
                {
                    barrelScript.popAttempt(gameObject);
                }
            }
        }
    }
}
