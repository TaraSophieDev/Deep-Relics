using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SubmarineController : MonoBehaviour {

    public Rigidbody rbSm;

    public int maxSpeed = 15;
    public int forwardAccel = 5;
    public int backwardsAccel = 5;
    public int turnSpeed;
    public int levitationSpeed = 10;

    void Start() {
        
    }

    void FixedUpdate() {
        SubmarineMovement();
        SubmarineTurn();
        SubmarineLevitate();
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

    void SubmarineLevitate() {
        if (Input.GetKey("q")) {
            rbSm.AddForce(Vector3.down * levitationSpeed);
        } else if (Input.GetKey("e")) {
            rbSm.AddForce(Vector3.up * levitationSpeed);
        }
    }
}
