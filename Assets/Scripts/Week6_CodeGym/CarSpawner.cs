using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> carPrefabs;
    private Vector2 carLocation;
    private float randomY;

    private int randomSelector;
    public int numberOfCars;

    public GameObject player;

    public List<GameObject> spawnedCars;

    public GameObject victoryScreen;
    public Image victoryImage;
    public Color victoryCol;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victoryScreen.SetActive(false);
        SpawnCars();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < spawnedCars.Count; i++)
        {
            //distance between the cars and player
            float distance = Vector2.Distance(spawnedCars[i].transform.position, player.transform.position);
            if (distance < 0.6)
            {
                Restart();
            }

            if(player.transform.position.y >= 5)
            {
                Victory();
            }
            else
            {
                victoryScreen.SetActive(false);
            }

        }


    }

    public void SpawnCars()
    {
        //select a random car and random spawn for each car youd want (numberofcars)
        for (int i = 1; i <= numberOfCars; i++)
        {
            //choose a random number between 0 and the amount of cars in prefab array
            randomSelector = Random.Range(0, carPrefabs.Count);
            //choose a random range for y
            randomY = Random.Range(-3, 4);
            //have the vector 2 be -13x and random y
            carLocation = new Vector2(-13, randomY);

            //instantiate the randomly selected prefab at the randomly selected y position, have its rotation be the same as the spawner
            GameObject car = Instantiate(carPrefabs[randomSelector], carLocation, transform.rotation);

            //add the instantiated car to another arraylist (this will be used for hit detection)
            spawnedCars.Add(car);
        }
    }

    public void Restart()
    {
        //set player back to starting point
        player.transform.position = new Vector3(0, -4.5f, 0);
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        victoryImage.color = victoryCol;
    }
}
