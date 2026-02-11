using UnityEngine;

public class RandomColour : MonoBehaviour
{
    public SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRandomColour()
    {
        sr.color = Random.ColorHSV();
    }
}
