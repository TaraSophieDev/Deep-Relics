using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody))]
public class SubmarineController : MonoBehaviour {

    public Rigidbody rbSm;
    public Camera camera;
    public RelicCounter relicCounter;

    public int vRotationSpeed = 15;
    public float minRotation = -80f;
    public float maxRotation = 80f;
    private Vector3 rotationCam;

    public int maxSpeed = 15;
    public int forwardAccel = 5;
    public int backwardsAccel = 5;
    public int turnSpeed = 50;
    public int ascendSpeed = 10;

    public AudioMixerSnapshot levelSnapshot;
    public AudioMixerSnapshot chaseSnapshot;

    private void Update() {
        MusicTransition();
    }

    void FixedUpdate() {
        SubmarineMovement();
        SubmarineStrafe();
        SubmarineTurn();
        SubmarineAscend();

        CameraYRotation();
    }

    void SubmarineMovement() {
        if (Input.GetKey("w")) {
            rbSm.AddForce(rbSm.transform.forward * maxSpeed);
        } 
        else if(Input.GetKey("s")){
            rbSm.AddForce(-rbSm.transform.forward * maxSpeed);
        }
        //Vector3 localVelocity = transform.InverseTransformDirection(rbSm.velocity);
        //localVelocity.x = 0;
        //rbSm.velocity = transform.TransformDirection(localVelocity);
    }

    void SubmarineTurn() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            //rbSm.AddTorque(Vector3.up * turnSpeed);
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            //rbSm.AddTorque(-Vector3.up * turnSpeed);
            rbSm.transform.rotation = Quaternion.Euler(rbSm.transform.rotation.eulerAngles + new Vector3(0f, -turnSpeed * Time.deltaTime, 0));
        }
    }

    void SubmarineStrafe() {
        if (Input.GetKey("a")) {
            rbSm.AddForce(-rbSm.transform.right * maxSpeed);
        }
        else if (Input.GetKey("d")) {
            rbSm.AddForce(rbSm.transform.right * maxSpeed);
        }
    }

    void SubmarineAscend() {
        if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftControl)) {
            rbSm.AddForce(Vector3.down * ascendSpeed);
        } 
        else if (Input.GetKey("e") || Input.GetKey(KeyCode.Space)) {
            rbSm.AddForce(Vector3.up * ascendSpeed);
        }
    }

    private void CameraYRotation() {
        if (Input.GetKey(KeyCode.DownArrow)) {
            rotationCam += new Vector3(vRotationSpeed * Time.deltaTime, 0);
            rotationCam.x = Mathf.Clamp(rotationCam.x, minRotation, maxRotation);
            camera.transform.localEulerAngles = rotationCam;
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            rotationCam -= new Vector3(vRotationSpeed * Time.deltaTime, 0);
            rotationCam.x = Mathf.Clamp(rotationCam.x, minRotation, maxRotation);
            camera.transform.localEulerAngles = rotationCam;
        }
        
    }

    //TODO: delete it before releasing
    void MusicTransition() {
        if (Input.GetKey("o")) {
            chaseSnapshot.TransitionTo(1f);
        }
        else if (Input.GetKey("i")) {
            levelSnapshot.TransitionTo(1f);
        }
        
    }
}
