using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public int knifeAmount=5;
    public GameObject knifeObject;
    public List<GameObject> knifeList;
    public float randomChance = 0.1f;
    public TextMeshProUGUI winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnKnives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnKnives()
    {
        float rotationAmount = 360 / knifeAmount;
        float curRotation = 0;
        for (int i = 0; i < knifeAmount; i++)
        {//spawn knives around barrel
            GameObject curKnife = Instantiate(knifeObject, transform.position, Quaternion.identity);
            //assign barrel to knife
            knife knifeScript = curKnife.GetComponent<knife>();
            knifeScript.myBarrel = gameObject;

            //change rotation
            Vector3 knifeRotation = Vector3.zero;
            knifeRotation.z = curRotation+90;
            curKnife.transform.eulerAngles = knifeRotation;

            //change position based on rotation
            Vector3 knifePosition = transform.position;
            float radianRotation = Mathf.Deg2Rad * curRotation;
            float knifeDistance = 3;
            knifePosition.x += knifeDistance * Mathf.Cos(radianRotation);
            knifePosition.y += knifeDistance * Mathf.Sin(radianRotation);
            curKnife.transform.position = knifePosition;

            //add to list
            knifeList.Add(curKnife);
            //increment rotation
            curRotation += rotationAmount;
        }
    }

    public void popAttempt(GameObject callingKnife)
    {
        float randomRoll = Random.value; //returns 0-1
        if (randomRoll <= randomChance)
        {//succesful chance, pop the barrel
            winText.text = "Lose";
            Debug.Log("Popped");
            gameObject.SetActive(false);
        }
        else
        {//failed chance, destroy the knife
            Debug.Log("Destroyed knife");
            if (callingKnife != null)
            {
                knifeList.Remove(callingKnife);
                Destroy(callingKnife);
            }
        }
        //check for win condition
        if (knifeList.Count <= 0)
        {//win
            winText.text = "Win";
        }

    }
}
