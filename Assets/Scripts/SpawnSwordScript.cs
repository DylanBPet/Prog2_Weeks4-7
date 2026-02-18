using UnityEngine;
using System.Collections.Generic;

public class SpawnSwordScript : MonoBehaviour
{
    public Transform playerPos;

    public int r;
    public int numberOfSwords = 10;

    public List<Transform> spawnPoints;

    public List<GameObject> swords;

    //sword prefab
    public GameObject sword;

    //spawned sword reference point
    public GameObject spawnedSword;

    private float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSwords()
    {
        for(int i = 0; i < numberOfSwords; i++)
        {
           r = Random.Range(0, spawnPoints.Count);
            spawnedSword = Instantiate(sword, spawnPoints[r]);
            swords.Add(spawnedSword);
            
        }
        
    }
    public void AimAtLara()
    {
        for(int i = 0; i < swords.Count; i++)
        {
            Vector2 direction = playerPos.transform.position - swords[i].transform.position;
            swords[i].transform.right = direction;

        }
    }

    public void LaunchSwords()
    {
        for (int i = 0; i < swords.Count; i++)
        {

            swords[i].transform.position += swords[i].transform.right * speed * Time.deltaTime;

        }
    }
}
