using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float playerSpeed = 3;
    private Vector3 spawnPosition;

    public GameObject carToSpawn;
    public List<GameObject> spawnList;
    public int carsToSpawn = 3;

    public TextMeshProUGUI winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPosition = transform.position;
        SpawnCars();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition=transform.position;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            oldPosition.x -= playerSpeed*Time.deltaTime;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            oldPosition.x += playerSpeed * Time.deltaTime;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            oldPosition.y += playerSpeed * Time.deltaTime;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            oldPosition.y -= playerSpeed * Time.deltaTime;
        }

        if (oldPosition.x >= 5)
            {
            winText.text = "Win Frogger";
            }

        transform.position = oldPosition;

        bool carCollision = false;
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i].GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
            {
                carCollision = true;
            }
            
        }
        if (carCollision)
        {
            getHit();
        }


    }

    public void getHit()
    {
        transform.position = spawnPosition;
    }

    void SpawnCars()
    {
        Vector3 spawnPosition = Vector3.zero;
        for (int i = 0; i < carsToSpawn; i++)
        {

            spawnPosition.x += 2f;
            spawnPosition.y = Random.Range(-3, 3);

            GameObject newCar = Instantiate(carToSpawn, spawnPosition, Quaternion.identity);
            spawnList.Add(newCar);
        }
    }
}
