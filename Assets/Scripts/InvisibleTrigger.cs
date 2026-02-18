using UnityEngine;
using UnityEngine.Events;

public class InvisibleTrigger : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer trigger;
    public bool isInHazard;

    public UnityEvent OnFirstEnter;
    public UnityEvent OnInsideSensor;
    public UnityEvent OnExitSensor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.bounds.Contains(player.transform.position))
        {
            if(isInHazard == true)
            {
                //was in hazard last frame, still is in hazard
                OnInsideSensor.Invoke();
            }
            else
            {
                //was not in hazard last frame, but is now
                //Aim At Laura
                OnInsideSensor.Invoke();

                //instantiate swords
                OnFirstEnter.Invoke();

                isInHazard = true;

            }
        }
        else
        {
            if (isInHazard == true)
            {
                //you were in hazard last frame, but are not anymore
                isInHazard = false;

                //launch swords
                OnExitSensor.Invoke();
            }
            else
            {
                //you are still not inside the hazard
                OnExitSensor.Invoke();
            }
        }
    }
}
