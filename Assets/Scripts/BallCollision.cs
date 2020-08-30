using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.GetComponent<Rigidbody>().velocity * -1;
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
