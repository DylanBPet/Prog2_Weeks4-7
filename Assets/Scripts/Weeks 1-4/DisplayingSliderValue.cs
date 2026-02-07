using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayingSliderValue : MonoBehaviour
{

    public TextMeshProUGUI sliderDisplayText;
    public Slider sliderTopMiddle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderDisplayText.text = sliderTopMiddle.value.ToString();
    }
}
