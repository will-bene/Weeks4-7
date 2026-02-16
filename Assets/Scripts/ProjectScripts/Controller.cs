using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //-- Initialize variables --
    //customer prefab object
    public GameObject customerPrefab;

    //sliders to get data from
    public Slider rotationSlider;
    public Slider scaleSlider;
    public Slider colorSlider;

    //currently spawned customer
    private GameObject currentCustomer;

    //margin of error from slider to actual value (as a fraction of max slider value, ex 0.1 > 10 percent)
    public float valueMargin = 0.05f; //allowed to be within 5% of target

    //game score
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCustomer()
    {
        currentCustomer = Instantiate(customerPrefab, transform);
    }

    public bool CheckValue(float value1, float value2, float marginAmount)
    {//check two values to see if they match within a margin of error, returing true or false

        //-- Gets the absolute 'distance' between values, comparing to see if they fit within margin amount --
        if (Mathf.Abs(value1-value2)<=marginAmount) 
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    public void CheckCustomerValues()
    {
        if (currentCustomer != null)
        {//check if customer exists

            //-- Gather customer order values --
            Customer customerScript = currentCustomer.GetComponent<Customer>();
            float orderRotation = customerScript.customerAngle;
            float orderScale = customerScript.customerScale;
            float orderColor = customerScript.customerColor;

            //-- Gather current item slider values --
            float itemRotation = rotationSlider.value;
            float itemScale = scaleSlider.value;
            float itemColor = colorSlider.value;

            //-- Gather margin of errors based on slider totals and margin percentage --
            float rotationMargin = (rotationSlider.maxValue + rotationSlider.minValue) * valueMargin;
            float scaleMargin = (scaleSlider.maxValue + scaleSlider.minValue) * valueMargin;
            float colorMargin = (colorSlider.maxValue + colorSlider.minValue) * valueMargin;

            //-- Compare values, returning true if all are within margin of error --
            bool passCheck = false;
                //all must be true to pass the check
            if (CheckValue(orderRotation, itemRotation, rotationMargin)
                && CheckValue(orderScale, itemScale, scaleMargin)
                && CheckValue(orderColor, itemColor, colorMargin)   )
            {
                passCheck = true;  
            }

            if (passCheck)
            {//passed check! add a point to score
                score++;
            }

            //regardless, delete customer and move on to new one
            Destroy(currentCustomer);
            SpawnCustomer();

        }
    }
}
