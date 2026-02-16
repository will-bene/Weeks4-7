using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //-- Initialize variables --
    //customer prefab object
    public GameObject customerPrefab;
    //item on-sell prefab object
    public GameObject onSellPrefab;

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
    public TextMeshProUGUI scoreUI;

    //timer
    public float orderTimerMax = 10;
    public float orderTimer;
    public Image timerDisplay;

    //audio
    public AudioSource SFXPlayer;
    public AudioClip SFXCorrect;
    public AudioClip SFXWrong;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        //incrment timer
        orderTimer-= Time.deltaTime;
        //change timer visual UI display based on timer value (0-1)
        timerDisplay.fillAmount = orderTimer/orderTimerMax;

        if (orderTimer <=0)
        {//when timer is up force a check of your item, will automatically spawn a new customer and reset timer at the end
            CheckCustomerValues();
        }
    }

    public void SpawnCustomer()
    {//spawn a new customer from the prefab
        //reset timer
        orderTimer = orderTimerMax;
        //spawn a customer, put a reference of it into the current customer tracker variable
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
                //play SFX
                SFXPlayer.clip = SFXCorrect;
                SFXPlayer.Play();

            }
            else
            {//wrong, play wrong sfx and reset score
                score = 0;
                SFXPlayer.clip = SFXWrong;
                SFXPlayer.Play();
            }
            //set score text to current score
            scoreUI.text = "$" + score.ToString();

            //spawn an item animation (matching item's exact values) that moves it to the customer, destroyign it after a couple seconds
            GameObject sellPrefab = Instantiate(onSellPrefab);
            //Adjust item animation rotation
            Vector3 rot = Vector3.zero;
            rot.z = itemRotation;
            sellPrefab.transform.eulerAngles = rot;
            //Adjust item animation scale
            Vector3 scale = Vector3.one;
            scale.x = itemScale; scale.y = itemScale;
            sellPrefab.transform.localScale = scale;
            //Adjust item animation color
            SpriteRenderer sr = sellPrefab.GetComponent<SpriteRenderer>();
            Color newColor = new Color();
            newColor = Color.HSVToRGB(itemColor, 0.6f, 1f);
            sr.color = newColor;

            //destroy item animation after 0.2 seconds
            Destroy( sellPrefab, 0.2f );


            //regardless, delete customer (giving it a few seconds to move away) and move on to new one
            customerScript.MoveAway(passCheck);
                Destroy(currentCustomer, 3);
            SpawnCustomer();

        }
    }
}
