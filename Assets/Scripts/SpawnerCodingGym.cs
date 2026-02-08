using UnityEngine;

public class SpawnerCodingGym : MonoBehaviour
{
    public GameObject objToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Vector3 spawnPos = Random.insideUnitCircle*2;

        Instantiate(objToSpawn, spawnPos, Quaternion.identity);
    }
}
