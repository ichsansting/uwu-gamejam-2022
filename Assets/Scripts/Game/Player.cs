using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    FixedJoint2D fixedJoint2D;
    Rigidbody2D rigidbody2d;

    public int wheelTouched = 0;
    public WheelJoint2D wheel1, wheel2;

    void Start()
    {
        fixedJoint2D = GetComponent<FixedJoint2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void Brake(GameObject wheel){
        wheelTouched++;
        if(wheelTouched == 2){
            Invoke("DelayBrake", 1);
        }
    }

    void DelayBrake(){
        wheel1.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        wheel2.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        wheel1.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        wheel2.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void NoBrake(){
        wheelTouched = 0;
        wheel1.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        wheel2.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
