using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SubmarineController : MonoBehaviour {

    public Rigidbody rbSm;

    public int maxSpeed = 15;
    public int forwardAccel = 5;
    public int backwardsAccel = 5;
    public int turnSpeed = 100;
    public int ascendSpeed = 10;

    void Start() {
        
    }

    void FixedUpdate() {
        SubmarineMovement();
        SubmarineTurn();
        SubmarineAscend();
    }

    void SubmarineMovement() {
        if (Input.GetKey("w")) {
            rbSm.AddRelativeForce(transform.forward * maxSpeed);
        } 
        else if(Input.GetKey("s")){
            rbSm.AddRelativeForce(-transform.forward * maxSpeed);
        }
        //Vector3 localVelocity = transform.InverseTransformDirection(rbSm.velocity);
        //localVelocity.x = 0;
        //rbSm.velocity = transform.TransformDirection(localVelocity);
    }

    void SubmarineTurn() {
        if (Input.GetKey("d")) {
            //rbSm.AddTorque(Vector3.up * turnSpeed);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey("a")) {
            //rbSm.AddTorque(-Vector3.up * turnSpeed);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -turnSpeed * Time.deltaTime, 0));
        }
    }

    void SubmarineAscend() {
        if (Input.GetKey("q")) {
            rbSm.AddForce(Vector3.down * ascendSpeed);
        } else if (Input.GetKey("e")) {
            rbSm.AddForce(Vector3.up * ascendSpeed);
        }
    }

    //WIP NOT USED
    void SubmarineVControls() {
        if (Input.GetKey("up")) {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-turnSpeed * Time.deltaTime, 0f, 0f));
        } else if (Input.GetKey("down")) {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(turnSpeed * Time.deltaTime, 0f, 0f));
        }
    }
}
