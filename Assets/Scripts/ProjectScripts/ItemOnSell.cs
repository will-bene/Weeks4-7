using UnityEngine;

public class ItemOnSell : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public AnimationCurve curve;
    private float animationProgress = 0;
    public float animationDuration = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //-- Set ending position to customer --
        startPos = transform.position;
        endPos = transform.position;
        endPos.y += 8;
        endPos.x += 2;
    }

    // Update is called once per frame
    void Update()
    {
        //-- Change position based on animation curve --
        animationProgress += Time.deltaTime/animationDuration;
        transform.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(animationProgress));
    }
}
