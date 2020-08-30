using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnspeed = 10f;
    private float speed = 100f;
    public GameObject PlayerDontGoBelowY;
    private float PlayerY;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerY = PlayerDontGoBelowY.transform.position.y;
        if (PlayerY < 7)
        {
            MovePlayerForward();
            MovePlayerBackward();
            RotatePlayerClockwise();
            RotatePlayerAntiClockwise();
            RotatePlayerDown();
            RotatePlayerUp();
            PlayerY++;
        }
        else if (PlayerY >= 7)
        {
            PlayerY--;
        }

    }

    void MovePlayerForward()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void MovePlayerBackward()
    {
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
        }
      
    }
    void RotatePlayerClockwise()
    {
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0, 0.5f * turnspeed, 0 *Time.deltaTime,Space.World);
        }
    }
    void RotatePlayerAntiClockwise()
    {
        if (Input.GetKey("left"))
        {
            this.transform.Rotate(0, -0.5f * turnspeed, 0 * Time.deltaTime, Space.World);
        }
    }
    void RotatePlayerDown()
    {
        if (Input.GetKey("down"))
        {
            this.transform.Rotate(0,0, -10 * turnspeed * Time.deltaTime);
        }
    }
    void RotatePlayerUp()
    {
        if (Input.GetKey("up"))
        {
            this.transform.Rotate(0,0, 10 * turnspeed * Time.deltaTime);
        }
    }

}
