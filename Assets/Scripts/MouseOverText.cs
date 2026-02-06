using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseOverText : MonoBehaviour
{
    public string myName;
    public TextMeshProUGUI textToChange;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        bool mousedOver = sr.bounds.Contains(mousePos);
        if (mousedOver)
        {
            textToChange.text = myName;
            //textToChange.
        }
    }

    public void changeColor()
    {
        sr.color = Random.ColorHSV();
    }

    public void changeRotation(float rot)
    {
        Vector3 oldAngle = Vector3.zero;
        oldAngle.z = rot;
        transform.eulerAngles = oldAngle;
    }

}
