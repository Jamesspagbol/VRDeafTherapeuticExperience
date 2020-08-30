using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    private bool gotDogBall;
    private bool gotDogBeagleDog;
    public bool balltouched;
    public bool ballthrown;
    public bool dogtouched;
    public bool hitground;
    public GameObject DogBall;
    public Vector3 DogBallPos;
    public GameObject DogBeagleDog;
    public GameObject Hand_White;
    private string BallContent;
    private string DogContent;
    

    void Start()
    {
        
    }
    void Update()
    {
        if (DogBall.transform.position.y < 1f)
        {
            hitground = true;
            DogBallPos = DogBall.transform.position;
            DogBall.GetComponent<DogBallPath>().velocity = 0f * this.transform.right;
            DogBall.GetComponent<DogBallPath>().acceleration = 0f * this.transform.up;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            if (gotDogBall == true)
            {
            return;
            }
            if (gotDogBeagleDog == true)
            {
            return;
             }
            BallInfo collidedBall = other.GetComponent<BallInfo>();

            if (collidedBall)
            {
               balltouched = true;
                gotDogBall = true;
                DogBall = other.gameObject;
                BallContent = collidedBall.balltype;
            }
            DogInfo collidedDog = other.GetComponent<DogInfo>();
             if (collidedDog)
            {
            dogtouched = true;
            gotDogBeagleDog = true;
            DogBeagleDog = other.gameObject;
            DogContent = collidedDog.DogType;       
            }

    }
    private void OnTriggerStay(Collider other)
    {
            BallInfo collidedBall = other.GetComponent<BallInfo>();
            if (Input.GetKey("a"))
            {
                if (collidedBall)
                {
                balltouched = true;
                    if (gotDogBall == true && BallContent == collidedBall.balltype)
                    {
                        collidedBall.transform.position = Hand_White.transform.position;
                    }
                }
            }
            if (Input.GetKey("d"))
            {
                collidedBall.GetComponent<DogBallPath>().velocity = 30.0f * this.transform.right;
                collidedBall.GetComponent<DogBallPath>().acceleration = -10.0f * this.transform.up;
            }
        DogInfo collidedDog = other.GetComponent<DogInfo>();
        if (Input.GetKey("r"))
        {
            DogBeagleDog.transform.position = DogBeagleDog.transform.position + new Vector3(0, 1, 0);
            StartCoroutine(BeagleJump());
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        balltouched = false;
        ballthrown = true;
        //dogtouched = false;
    }
    IEnumerator BeagleJump()
    {
        DogBeagleDog.transform.position = DogBeagleDog.transform.position + new Vector3(0, 0, 0);
        dogtouched = false;

        yield return new WaitForSeconds(0.3f);
    }

}
