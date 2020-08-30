using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    enum DogStates {DogStart, DogRoaming, DogStill, DogReturnToPicnicRug, DogJump, DogGoToBall}
    DogStates CurrentDogState;
    public GameObject BeagleDog;
    public GameObject BallPos;
    private Vector3 BallPosPosition;
    public GameObject Hand;
    private float DogSpeed = 45.0f;
    private float DogPointX;
    private float DogPointY;
    private float DogPointZ;
    private Vector3 DogPoint2;
    private Vector3 DogPoint3;
    private Vector3 JumpPos1;
    private Vector3 JumpPos2;
    private bool hasPosition = false;

    void Start()
    {

    }

    void Update()
    {

        switch (CurrentDogState)
        {
            case DogStates.DogStart:
                if (hasPosition == false)
                {
                    GetDogPoint();
                    BeagleDog.transform.position = new Vector3(36.5f, 0.3f, -3.1f);
                    hasPosition = true;
                }
                CurrentDogState = DogStates.DogRoaming;
                break;
            case DogStates.DogRoaming:
                 if (Hand.GetComponent<HandCollision>().balltouched == true || Hand.GetComponent<HandCollision>().dogtouched == true)
                 {
                    CurrentDogState = DogStates.DogReturnToPicnicRug;
                 }
                 if (Hand.GetComponent<HandCollision>().balltouched == false || Hand.GetComponent<HandCollision>().dogtouched == false)
                 {
                 AutonomousDogMovement();
                 }
                break;
            case DogStates.DogStill:
                if (Input.GetKey("r"))
                {
                    CurrentDogState = DogStates.DogJump;
                }
                else
                {
                    StartCoroutine(DogWaitBeforeRoam());
                }
                break;
            case DogStates.DogReturnToPicnicRug:
               
                    if (BeagleDog.transform.position == DogPoint3)
                    {
                        GetDogPoint2();
                    }
                    if (BeagleDog.transform.position != DogPoint3)
                    {
                        BeagleDog.transform.position = Vector3.MoveTowards(BeagleDog.transform.position, DogPoint3, Time.deltaTime * DogSpeed);
                    }
                if (Hand.GetComponent<HandCollision>().balltouched == false && Hand.GetComponent<HandCollision>().ballthrown == true)
                {
                    CurrentDogState = DogStates.DogGoToBall;
                }
                    break;
            case DogStates.DogJump:
                StartCoroutine(BeagleJump());
                break;
            case DogStates.DogGoToBall:
                BallPos = Hand.GetComponent<HandCollision>().DogBall;
                StartCoroutine(DogBallThrownWait());
                if (Hand.GetComponent<HandCollision>().ballthrown == true && Hand.GetComponent<HandCollision>().hitground == true)
                {
                    CurrentDogState = DogStates.DogStill;
                }
                break;
        }
    }
    void AutonomousDogMovement()
    {
        if(BeagleDog.transform.position == DogPoint2)
        {
            GetDogPoint();
        }
        if (BeagleDog.transform.position != DogPoint2)
        {
            BeagleDog.transform.position = Vector3.MoveTowards(BeagleDog.transform.position, DogPoint2, Time.deltaTime * DogSpeed);
        }
    }
    void GetDogPoint()
    {
        DogPointX = Random.Range(-200f, 200f);
        DogPointY = 0.3f;
        DogPointZ = Random.Range(-200F, 200F);
        DogPoint2 = new Vector3(DogPointX, DogPointY, DogPointZ);
    }
    void GetDogPoint2()
    {
        DogPointX = Random.Range(-50f, 50f);
        DogPointY = 0.3f;
        DogPointZ = Random.Range(-50f, 50f);
        DogPoint3 = new Vector3(DogPointX, DogPointY, DogPointZ);
    }
    IEnumerator DogBallThrownWait()
    {
        yield return new WaitForSeconds(3f);
        BallPosPosition = BallPos.transform.position;
        BeagleDog.transform.position = Vector3.MoveTowards(BeagleDog.transform.position, BallPosPosition, Time.deltaTime * DogSpeed);
    }
    IEnumerator BeagleJump()
    {
        JumpPos1 = new Vector3(BeagleDog.transform.position.x, 1f, BeagleDog.transform.position.z);
        JumpPos2 = new Vector3(BeagleDog.transform.position.x, 0.3f, BeagleDog.transform.position.z);
        BeagleDog.transform.position = Vector3.MoveTowards(BeagleDog.transform.position, JumpPos1, Time.deltaTime * DogSpeed);
        yield return new WaitForSeconds(0.5f);
        BeagleDog.transform.position = Vector3.MoveTowards(BeagleDog.transform.position, JumpPos2, Time.deltaTime * DogSpeed);
        Hand.GetComponent<HandCollision>().balltouched = false;
        Hand.GetComponent<HandCollision>().dogtouched = false;
        Hand.GetComponent<HandCollision>().ballthrown = false;
        Hand.GetComponent<HandCollision>().hitground = false;
        CurrentDogState = DogStates.DogReturnToPicnicRug;
    }
    IEnumerator DogWaitBeforeRoam()
    {
        yield return new WaitForSeconds(10f);
        Hand.GetComponent<HandCollision>().balltouched = false;
        Hand.GetComponent<HandCollision>().dogtouched = false;
        Hand.GetComponent<HandCollision>().ballthrown = false;
        Hand.GetComponent<HandCollision>().hitground = false;
        //balltouched = false;
        // dogtocuhed = false
        //ballthrown = false;
        //hitground = false;
        CurrentDogState = DogStates.DogRoaming;

    }
}
