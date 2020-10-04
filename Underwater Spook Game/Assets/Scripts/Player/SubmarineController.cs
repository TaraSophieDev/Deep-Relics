using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SubmarineController : MonoBehaviour {

    public Rigidbody rbSm;

    public int maxSpeed = 15;
    public int forwardAccel = 5;
    public int backwardsAccel = 5;
    public int turnSpeed = 50;
    private float speedInput = 0f;

    void Start() {
        
    }

    void FixedUpdate() {
        SubmarineMovement();
        SubmarineTurn();
    }

    void SubmarineMovement() {
        if (Input.GetKey("w")) {
            rbSm.AddRelativeForce(transform.forward * maxSpeed);
        } 
        else if(Input.GetKey("s")){
            rbSm.AddRelativeForce(-transform.forward * maxSpeed);
        }
        Vector3 localVelocity = transform.InverseTransformDirection(rbSm.velocity);
        localVelocity.x = 0;
        rbSm.velocity = transform.TransformDirection(localVelocity);
    }

    void SubmarineTurn() {
        if (Input.GetKey("d")) {
            rbSm.AddTorque(Vector3.up * turnSpeed);
        }
        else if (Input.GetKey("a")) {
            rbSm.AddTorque(-Vector3.up * turnSpeed);
        }
    }
}
