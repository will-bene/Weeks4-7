using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawningPrefab;


    private float waitProgress = 0f;
    public float waitDuration;

    private float destroyProgress = 0f;
    public float destroyDuration;

    public float pacerSpeed;
    public Color pacerColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy(gameObject, destroyDuration);
        //empty Vector3
        //Vector3 originPoisiton = Vector3.zero;

        //empty quaternion
        //Quaternion originRotation = Quaternion.identity;

        //Instantiate(spawningPrefab, transform.position, originRotation);

        //spawning at the spawner's location
        //Instantiate(spawningPrefab, transform.position, transform.rotation);

        //spawning at the origin (0, 0)
        //Instantiate(spawningPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        waitProgress += Time.deltaTime;
        if (waitProgress > waitDuration)
        {
            GameObject spawnedObject = Instantiate(spawningPrefab, transform.position, Quaternion.identity);
            Pacer spawnedPacer = spawnedObject.GetComponent<Pacer>();
            spawnedPacer.speed = pacerSpeed;

            //get SpriteRenderer of spawned object
            //componentType nameofObject = spawnnedObject.GetComponent<componentType>();
            SpriteRenderer spawnedColor = spawnedObject.GetComponent<SpriteRenderer>();
            spawnedColor.color = pacerColor;

            Destroy(spawnedObject, destroyDuration);

            waitProgress = 0f;
        }

        

        //destroyProgress += Time.deltaTime;
        //if (destroyProgress > destroyDuration)
        //{
        //    Destroy(gameObject);
        //    destroyProgress = 0f;
        //}
    }

    public void IncreasePacerSpeed()
    {
        pacerSpeed++;
    }
}
