using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnAmnt;
    public GameObject spawnObject;
    public List<GameObject> spawnedObjectList;
    public TextMeshProUGUI winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnAmnt; i++)
        {
            spawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedObjectList.Count<=0)
        {//no more enemies
            winText.text = "You Won!!!";
        }
    }

    public void spawnEnemy()
    {
        Vector2 spawnPos = Random.insideUnitSphere * 3;
        GameObject curSpawned = Instantiate(spawnObject, spawnPos, Quaternion.identity);
        EnemiesClicker curSpawnedScript = curSpawned.GetComponent<EnemiesClicker>();
        curSpawnedScript.spawnerObject = gameObject;
        spawnedObjectList.Add(curSpawned);
    }

    public void killEnemy()
    {//called for in enemy object when dying

    }
}
