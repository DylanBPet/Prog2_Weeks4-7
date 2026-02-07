using UnityEngine;
using UnityEngine.UI;

public class SliderScaling : MonoBehaviour
{
    public Slider rotationSlider;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = rotationSlider.value;
        transform.eulerAngles = newRotation;

    }
}
