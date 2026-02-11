using TMPro;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public TextMeshProUGUI spaceManButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleSetActive()
    {
        if(gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
            spaceManButton.text = "Goodbye";
        }
        else if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
            spaceManButton.text = "Greetings";
        }

        //OR you can do   --> gameObject.SetActive(!gameObject.activateInHierarchy) <--

    }

}
