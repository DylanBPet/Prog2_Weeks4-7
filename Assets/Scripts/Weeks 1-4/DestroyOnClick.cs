using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOnClick : MonoBehaviour
{
    private Vector2 mousePos;

    public SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
           // Debug.Log("mouse was pressed");
            if(sr.bounds.Contains(mousePos))
                {
                    Destroy(gameObject);
                //Debug.Log("was hit");
                }
        }


    }
}
