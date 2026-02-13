using UnityEngine;

public class car : MonoBehaviour
{
    public float carSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 oldTransform = transform.position;
        oldTransform.y=Random.Range(-3, 3);
        transform.position = oldTransform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldTransform = transform.position;
        oldTransform.y += carSpeed*Time.deltaTime;
        if (Camera.main.WorldToScreenPoint(oldTransform).y>Screen.height+100)
        {
            oldTransform.y = -6;
        }
        transform.position = oldTransform;
    }
}
