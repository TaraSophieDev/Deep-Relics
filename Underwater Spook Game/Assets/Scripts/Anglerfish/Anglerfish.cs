using System;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Anglerfish : MonoBehaviour {
    
    public float speed;
    private Transform target;
    public float turnSpeed = 0f;
    private Rigidbody rb;
    public float targetDistance; 

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        transform.Rotate(new Vector3(0, 90, 0));
    }

    private void Update() {

        LookAtPlayer();
        MoveToPlayer();
    }

    void LookAtPlayer() {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime / 10;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void MoveToPlayer() {
        targetDistance = Vector3.Distance(target.position, transform.position);
        Vector3 direction = target.position - transform.position;
        if (targetDistance > 40f) {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
