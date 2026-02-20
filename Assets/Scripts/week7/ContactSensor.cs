using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer hazardRenderer;
    private bool wasInHazard = false;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    //public UnityEvent<float> OnEnterValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hazardRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isInHazard = (hazardRenderer.bounds.Contains(player.position));
        if (isInHazard && !wasInHazard)
        {//player is inside hazard bounds
            wasInHazard = true;
            //WHAT WE WANT WHEN PLAYER ENTERS HAZARD BOUNDS
            OnEnter.Invoke();

        }
        else if (!isInHazard && wasInHazard)
        {
            wasInHazard = false;
            //WHAT WE WANT WHEN PLAYER EXITS BOUNDS
            OnExit.Invoke();

        }
    }
}
