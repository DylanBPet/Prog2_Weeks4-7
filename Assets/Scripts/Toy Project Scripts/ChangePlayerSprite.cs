using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerSprite : MonoBehaviour
{
    public Sprite pose1;
    public Sprite pose2;
    public Sprite pose3;

    private SpriteRenderer playerSr;

    public int playerCurrentSprite;

    public Slider newRotation;
    public Vector3 playerRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       playerRotation.z = newRotation.value;
        transform.eulerAngles = playerRotation;
    }

    public void ChangeToSprite1()
    {
        playerCurrentSprite = 0;
        playerSr.sprite = pose1;
    }

    public void ChangeToSprite2()
    {
        playerCurrentSprite = 1;
        playerSr.sprite = pose2;
    }

    public void ChangeToSprite3()
    {
        playerCurrentSprite = 2;
        playerSr.sprite = pose3;
    }
}
