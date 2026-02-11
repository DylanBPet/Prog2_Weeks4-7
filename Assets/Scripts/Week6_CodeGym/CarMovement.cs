using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speed;
    private Vector2 carTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(8, 16);
    }

    // Update is called once per frame
    void Update()
    {
        carTransform = transform.position;
        carTransform.x += speed * Time.deltaTime;

        if(carTransform.x >= 13)
        {
            carTransform.x = -13;
        }
        transform.position = carTransform;
    }
}
