using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsThisFoodGood : MonoBehaviour
{
    public bool isFoodGood;
    public TextMeshProUGUI itemDescription;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (sr.bounds.Contains(mousePos))
        {
            if (isFoodGood == true)
            {
                itemDescription.text = "Yummy!";
            }
            else if (isFoodGood == false)
            {
                itemDescription.text = "ew...";
            }
        }
      

    }
}
