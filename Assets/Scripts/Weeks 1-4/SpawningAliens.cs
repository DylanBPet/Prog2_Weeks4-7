using UnityEngine;
using UnityEngine.InputSystem;

public class SpawningAliens : MonoBehaviour
{
    public GameObject alienInvader;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(alienInvader, Random.insideUnitCircle * 5, Quaternion.identity);
        }
        */

        
        
    }

    public void SpawnAlien()
    {

        //STILL ONLY SPAWING IN A SPECIFIC AREA OUTSIDE THE SCREEN INSTEAD OF IN A CIRCLE ON THE OUTSIDE
        Vector2 spawnOutsideScreen = new Vector2(Random.Range(10, 12), Random.Range(10, 12));
        Vector2 randomRotatoin = new Vector2(Random.Range(10, 12),Random.Range(10, 12));
        Instantiate(alienInvader, spawnOutsideScreen, Quaternion.identity);
    }
}
