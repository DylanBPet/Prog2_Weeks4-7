using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    //the slider that is connected to the clock timer
    public Slider timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase the slider value by 1 per second
        timer.value += 1 * Time.deltaTime;
        //See GameControlScript - CorrectAnswer() for resetting Timer
        //See GameControlScript - YouLose() for what happeneds when timer reaches MaxValue
    }
}
