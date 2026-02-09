using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Item : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize color as starting slider position
        changeColor(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeColor(float col)
    {   //-- change color hue of item, called in color slider // value of hue is 0-1 --
        //get sprite renderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //create new color to change to based off of hue
        Color newColor = new Color();
        newColor = Color.HSVToRGB(col, 1f, 1f);

        //set sprite to be that color
        spriteRenderer.color = newColor;
    }

    public void changeScale(float scl)
    {   //-- change scale of object, called in size slider // value of scale is 0.5-3 --
        //initialize empty scale vector
        Vector3 newScale = Vector3.one;
        //change x and y scaling value to be scale value
        newScale.x = scl;
        newScale.y = scl;
        //set size of self to be new scalar
        transform.localScale = newScale;
    }

}
