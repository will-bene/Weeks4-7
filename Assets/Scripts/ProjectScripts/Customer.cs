using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    //-- Initialize variables --
    public float customerAngle; //order Angle
    public float customerScale; //order Scale
    public float customerColor; //order Color

    //labels of values in order UI
    public TextMeshProUGUI angleLabel;
    public TextMeshProUGUI scaleLabel;
    public TextMeshProUGUI colorLabel;

    //item sprite in UI to change appearance of
    public Image orderItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //-- Randomize customer 'order' values, set labels to that value --
        customerAngle = Random.Range(0, 360); angleLabel.text = customerAngle.ToString();
        //Uses string formatting ("F2") to force-show only two decimal points of the floats, cutting down the string size
        //Found earlier in Unity documentation for ToString() https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Vector3.ToString.html
        customerScale = Random.Range(0.5f, 2.5f); scaleLabel.text = customerScale.ToString("F2");
        customerColor = Random.Range(0f, 1f); colorLabel.text = customerColor.ToString("F2");

        //-- Change item sprite's euler angle rotation --
        Vector3 itemRotation = Vector3.zero;
        itemRotation.z = customerAngle;
        orderItem.rectTransform.eulerAngles = itemRotation;

        //-- Change item sprite's scaling --
        Vector3 itemScale = Vector3.one;
        itemScale.x = customerScale*0.4f; itemScale.y = customerScale*0.4f; //Hard to get scaling between this order item (UI item) and the real item (World-Space Game Object), but *0.4 is about the right conversion
        orderItem.rectTransform.localScale = itemScale;

        //-- Change item sprite's color --
        Color newColor = new Color();
        newColor = Color.HSVToRGB(customerColor, 1f, 1f);
        orderItem.color = newColor;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
