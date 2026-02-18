using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;

    public UnityEvent OnEnterSensor;
    public UnityEvent OnExitSensor;

    public UnityEvent<float> OnRandomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void Update()
    {

        if (hazard.bounds.Contains(transform.position) == true)
        {
            if(isInHazard == true)
            {
                //still in the hazard
            }
            else
            {
                //you entered the hazard
                isInHazard = true;
                OnEnterSensor.Invoke();
            }       
        }
        else
        {
            if (isInHazard == true)
            {
                //you were in hazard last frame, but not anymore
                isInHazard = false;
                OnRandomNumber.Invoke(Random.Range(0, 10));
               
            }
            else
            {
                //you are still outside the hazard
                OnExitSensor.Invoke();
            }
        }


    }

    public void ShowNumber(float number)
    {
        Debug.Log(number);
    }
}
