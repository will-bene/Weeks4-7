using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float curSpeed=0f;
    private float direction = 1;
    public float moveSpeed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curSpeed > 0)
        { transform.position += direction * transform.right * curSpeed * Time.deltaTime; }
    }

    public void onMoveClick()
    {
        curSpeed = moveSpeed; 
    }
    public void onStopClick()
    {
        curSpeed = 0;
    }
    public void onFlipClick()
    {
        direction *= -1;
    }
}
