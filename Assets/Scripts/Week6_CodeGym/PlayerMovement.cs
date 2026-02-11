using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when space is pressed, move in the direction player is looking
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            transform.position += transform.up;
        }

        //when a is pressed, rotate the player 90 degrees counterclockwise
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            playerRot = transform.eulerAngles;
            playerRot.z += 90;
            transform.eulerAngles = playerRot;
        }

        //when d is pressed, rotate the player 90 degreees clockwise
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            playerRot = transform.eulerAngles;
            playerRot.z -= 90;
            transform.eulerAngles = playerRot;
        }
    }
}
