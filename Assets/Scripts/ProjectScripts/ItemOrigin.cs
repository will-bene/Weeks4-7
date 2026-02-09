using UnityEngine;

public class ItemOrigin : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeRotation(float rot)
    {   //-- change rotation of item called in rotation slider // value of rot is 0-360 --
        //initialize empty rotation vector
        Vector3 newAngle = Vector3.zero;
        //change z rotation value to be rotation slider value
        newAngle.z = rot;
        //set euler angle of self to new rotation
        transform.eulerAngles = newAngle;
    }

}
