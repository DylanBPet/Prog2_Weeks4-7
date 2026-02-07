using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    public Slider timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.value += 1 * Time.deltaTime;

        if(timer.value > 10)
        {
            //Hide all ui but the start over
        }
    }
}
