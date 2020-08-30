using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    public GameObject BallHitTree;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        BallHitTree = other.gameObject;
        BallHitTree.GetComponent<DogBallPath>().velocity = -30.0f * this.transform.right;
        BallHitTree.GetComponent<DogBallPath>().acceleration = -10.0f * this.transform.up;
       // collidedBall.GetComponent<DogBallPath>().velocity = 30.0f * this.transform.right;
       // collidedBall.GetComponent<DogBallPath>().acceleration = -10.0f * this.transform.up;
    }
}
