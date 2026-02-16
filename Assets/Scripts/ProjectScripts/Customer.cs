using NUnit.Framework;
using System.Collections.Generic;
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
    public TextMeshProUGUI dialogueLabel; //randomly made dialogue (ex. "I want...")
    public List<string> randomDialogue; //list of random dialogue
    public TextMeshProUGUI angleLabel;
    public TextMeshProUGUI scaleLabel;
    public TextMeshProUGUI colorLabel;

    //item sprite in UI to change appearance of
    public Image orderItem;
    //color icon to change color of
    public Image colorUI;
    //order icons to change fill of
    public Image scaleIconFill;
    public Image rotationIconFill;


    //position and curve for smooth entrance movement
    private Vector3 startingPosition;
    private Vector3 offsetPosition;
    public AnimationCurve moveCurve;
    public float curveProgress = 0;
    public float curveDuration = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //-- Save initial position to move back to later --
        startingPosition = transform.position;
        //-- Offset initial position to move in from side --
        Vector3 curPosition=transform.position;
        curPosition.x += 20;
        transform.position = curPosition;
        offsetPosition = transform.position;

        //-- Randomize customer 'order' values, set labels to that value at same time --
        //Rotation
        customerAngle = Random.Range(0, 180); angleLabel.text = customerAngle.ToString()+ "°";
        //Uses string formatting ("F2") to force-show only two decimal points of the floats, cutting down the string size
        //Found earlier in Unity documentation for ToString() https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Vector3.ToString.html
        //Scale
        customerScale = Random.Range(0.5f, 3f); scaleLabel.text = customerScale.ToString("F2")+"x";
        //Color
        customerColor = Random.Range(0f, 0.9f); colorLabel.text = customerColor.ToString("F2");
        //Choose random dialogue from a list
        randomDialogue.Add("I want..."); randomDialogue.Add("Do you have..."); randomDialogue.Add("I'd like this!"); randomDialogue.Add("Can you get this?"); randomDialogue.Add("Have any of these?");
        dialogueLabel.text = randomDialogue[Random.Range(0, randomDialogue.Count-1)].ToString();



        //-- Change item sprite values based on randomized wants --
        //Change item sprite's euler angle rotation
        Vector3 itemRotation = Vector3.zero;
        itemRotation.z = customerAngle;
        orderItem.rectTransform.eulerAngles = itemRotation;

        //Change item sprite's scaling
        Vector3 itemScale = Vector3.one;
        itemScale.x = customerScale*0.4f; itemScale.y = customerScale*0.4f; //Hard to get scaling between this order item (UI item) and the real item (World-Space Game Object), but *0.4 is about the right conversion
        orderItem.rectTransform.localScale = itemScale;

        //Change item sprite's color
        Color newColor = new Color();
        newColor = Color.HSVToRGB(customerColor, 1f, 1f);
        orderItem.color = newColor;
        //change color UI sprite color
        colorUI.color = newColor;
        //change order UI icon's fill
        rotationIconFill.fillAmount = customerAngle / 180f;
        scaleIconFill.fillAmount = customerScale / 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //-- Move back to starting positon, makes it look like they're spawning in, uses animation curve to get position --
        curveProgress += Time.deltaTime/curveDuration;
        transform.position = Vector3.Lerp(offsetPosition, startingPosition, moveCurve.Evaluate(curveProgress));
    }

    public void MoveAway(bool succeeded)
    {//-- Move away to the left, your order is complete - Called for when destroyed by controller script --
        //change values used by lerp so you now move to the left before being destroyed a few seconds later
        offsetPosition = startingPosition;
        //startingPosition = transform.position;
        startingPosition.x -= 30;
        //reset curve progress so animation movement starts over again
        curveProgress = 0;
        //change dialogue to show completion based on check success
        if (succeeded)
        {
            dialogueLabel.text = "Thank you!";
        }
        else
        {
            dialogueLabel.text = "EW! What is this?!";
        }
    }
}
