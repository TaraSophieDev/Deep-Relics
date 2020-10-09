using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.UIElements;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SubmarineController : MonoBehaviour {

    public Rigidbody rbSm;
    public Camera camera;

    private int y = 15;
    private Vector3 rotationCam;

    public int maxSpeed = 15;
    public int forwardAccel = 5;
    public int backwardsAccel = 5;
    public int turnSpeed = 50;
    public int ascendSpeed = 10;

    void FixedUpdate() {
        SubmarineMovement();
        SubmarineTurn();
        SubmarineAscend();

        CameraVRotation();
    }

    void SubmarineMovement() {
        if (Input.GetKey("w")) {
            rbSm.AddRelativeForce(rbSm.transform.forward * maxSpeed);
        } 
        else if(Input.GetKey("s")){
            rbSm.AddRelativeForce(-rbSm.transform.forward * maxSpeed);
        }
        //Vector3 localVelocity = transform.InverseTransformDirection(rbSm.velocity);
        //localVelocity.x = 0;
        //rbSm.velocity = transform.TransformDirection(localVelocity);
    }

    void SubmarineTurn() {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
            //rbSm.AddTorque(Vector3.up * turnSpeed);
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
            //rbSm.AddTorque(-Vector3.up * turnSpeed);
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(0f, -turnSpeed * Time.deltaTime, 0));
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
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(-turnSpeed * Time.deltaTime, 0f, 0f));
        } else if (Input.GetKey("down")) {
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(turnSpeed * Time.deltaTime, 0f, 0f));
        }
    }

    private void CameraVRotation() {
        if (Input.GetKey(KeyCode.DownArrow)) {
            rotationCam = new Vector3(y * -1 * Time.deltaTime, 0);
            camera.transform.eulerAngles -= rotationCam;
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            rotationCam = new Vector3(y * 1 * Time.deltaTime, 0);
            camera.transform.eulerAngles -= rotationCam;
        }
    }
}
