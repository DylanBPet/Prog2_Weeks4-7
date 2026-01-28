using Mono.Cecil.Cil;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * 1 * Time.deltaTime;
    }
}
