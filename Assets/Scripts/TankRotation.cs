using UnityEngine;
using UnityEngine.InputSystem;

public class TankRotation : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject objToSpawn;
    public float destroyTime = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0;

        //setting the direction we're looking in, to get direction you get end-start
        transform.right = worldMousePosition - transform.position;

        bool mouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (mouseClicked)
        {
            GameObject spawnedObj = Instantiate(objToSpawn, transform.position, transform.rotation);
            Destroy(spawnedObj, destroyTime);
        }
    }
}
