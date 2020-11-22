using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
public class Anglerfish : MonoBehaviour {
    
    public float speed;
    private Transform target;
    public int rotationAngle = 90;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {

        transform.LookAt(target);
        if(Vector3.Distance(transform.position, target.position) > 100)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
