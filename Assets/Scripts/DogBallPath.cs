using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBallPath : MonoBehaviour
{
    public Vector3 acceleration = new Vector3(0, 0, 0);
    public Vector3 velocity = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = velocity + Time.deltaTime * acceleration;
        this.transform.position = this.transform.position + Time.deltaTime * velocity;
    }
}
