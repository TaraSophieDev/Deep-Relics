using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Anglerfish : MonoBehaviour {
    
    public float speed;
    private Transform target;
    public float turnSpeed = 0f;
    public Rigidbody rb;
    public float targetDistance;
    public int bitten;
    private Vector3 movement;
    public anglerfishState state = anglerfishState.chasing;

    public enum anglerfishState {
        chasing,
        biting
    }
    void Start() {
        //rb = this.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.Rotate(new Vector3(0, 90, 0));
        targetDistance = 100f;
    }

    private void Update() {
        
        targetDistance = Vector3.Distance(target.position, transform.position);
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        movement = direction;

        switch (state) {
            case anglerfishState.chasing:
                LookAtTarget();
                print("chasing");
                break;
            case anglerfishState.biting:
                print("biting");
                //Application.Quit();
                state = anglerfishState.chasing;
                break;
        }
    }

    private void FixedUpdate() {
        if (state == anglerfishState.chasing) {
            MoveToTarget(movement);
        }
    }

    void LookAtTarget() {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.fixedDeltaTime / 10;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void MoveToTarget(Vector3 direction) {
        if (targetDistance > 70f && state != anglerfishState.biting) {
            rb.velocity = direction * speed;
        }
        else if (targetDistance <= 50f && state == anglerfishState.chasing) {
            state = anglerfishState.biting;
            bitten++;
        }
    }
}
