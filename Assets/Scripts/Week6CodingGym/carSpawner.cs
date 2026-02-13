using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject carToSpawn;
    public int carsToSpawn = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCars()
    {
        Vector3 spawnPosition = Vector3.zero;
        for (int i = 0; i < carsToSpawn; i++) {

        spawnPosition.x += 2f;
            spawnPosition.y = Random.Range(-3, 3);
        Instantiate(carToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
