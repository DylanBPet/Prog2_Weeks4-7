using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float speed;
    Vector3 newRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newRotation.z += speed * Time.deltaTime;
        transform.eulerAngles = newRotation;

    }

    public void StartRotate()
    {
        speed = 100;
    }

    public void StopRotate()
    {
        speed = 0;
    }
}
