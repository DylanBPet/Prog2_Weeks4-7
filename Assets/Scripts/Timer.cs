using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerValue = 0;
    public float timerMaxValue = 10;

    public Image timerFill;
    public Slider timerVisuals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;

        if( timerValue > timerMaxValue )
        {
            timerValue = 0;
            timerFill.color = Color.white;
        }
        else if(timerValue >= 5)
        {
            timerFill.color = Color.yellow;
        }


            timerVisuals.value = timerValue;


    }
}
