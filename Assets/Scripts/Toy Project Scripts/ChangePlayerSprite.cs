using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerSprite : MonoBehaviour
{
    //A list of the Sprites the player can change into
    public Sprite pose1;
    public Sprite pose2;
    public Sprite pose3;

    //The players SpriteRenderer
    private SpriteRenderer playerSr;

    //The players current sprite (starting at 0 for sprite 1) This will be references in GameControlScript - DoIFit()
    public int playerCurrentSprite;

    //The slider above the player that will control its rotation
    public Slider newRotation;

    //The players rotatoin, controlled by the slider. This will be references in GameControlScript - DoIFit()
    public Vector3 playerRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning the sprite renderer
        playerSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerRotatoin z is assigned by the slider value
       playerRotation.z = newRotation.value;

        //Change the eulerAngle to equal playerRotation
        transform.eulerAngles = playerRotation;
    }

    public void ChangeToSprite1()
    {
        //Set currentSprite to 0, This will be references in GameControlScript - DoIFit()
        playerCurrentSprite = 0;
        //Change the player Sprite to pose1
        playerSr.sprite = pose1;
    }

    public void ChangeToSprite2()
    {
        //Set currentSprite to 1, This will be references in GameControlScript - DoIFit()
        playerCurrentSprite = 1;
        //Change the player Sprite to pose2
        playerSr.sprite = pose2;
    }

    public void ChangeToSprite3()
    {
        //Set currentSprite to 2, This will be references in GameControlScript - DoIFit()
        playerCurrentSprite = 2;
        //Change the player Sprite to pose3
        playerSr.sprite = pose3;
    }
}
