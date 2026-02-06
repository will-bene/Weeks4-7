using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemiesClicker : MonoBehaviour
{
    public float HP;
    public TextMeshProUGUI hpLabel;
    public GameObject spawnerObject; //set as spawner object
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hpLabel.text = HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        bool mousedOver = sr.bounds.Contains(mousePos);
        if (mousedOver)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {//mouse clicked over object
                if (HP > 1)
                {//still has hp to lose
                    HP--;
                    hpLabel.text = HP.ToString();
                }
                else
                {//die
                    gameObject.SetActive(false);

                }
            }
            
        }
    }
}
