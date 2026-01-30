using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public SpriteRenderer player;
    public Slider healthBar;
    public int health = 100;

    public GameObject revivePlayerButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        healthBar.maxValue = health;
        healthBar.value = health;
        revivePlayerButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if(player.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            health -= 10;

            if(health <= 0)
            {
                gameObject.SetActive(false);
                revivePlayerButton.SetActive(true);
            }
        }

        healthBar.value = health;

    }

    public void RevivePlayer()
    {
        gameObject.SetActive(true);

        health = (int)healthBar.maxValue;

        healthBar.value = health;

        revivePlayerButton.SetActive(false);
    }
}
