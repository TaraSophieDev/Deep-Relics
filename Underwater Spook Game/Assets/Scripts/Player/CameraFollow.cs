using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Quaternion rotation = Quaternion.identity;
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    private void FixedUpdate() {
        //Vector3 desiredPos = target.position + offset;
        //Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, smoothSpeed);
        //transform.position = smoothedPos;
        //transform.eulerAngles = new Vector3(90, target.transform.eulerAngles.y, 0);
        //transform.LookAt(target);
    }

}
