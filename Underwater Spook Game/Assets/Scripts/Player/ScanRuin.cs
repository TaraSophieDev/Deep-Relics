using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScanRuin : MonoBehaviour {

    public float range = 0;
    
    public ScanState state = ScanState.ready;
    public enum ScanState {
        ready,
        scanning
    }
    void Start() {
        
    }
    
    void Update() {
        if (Input.GetKey("f")) {
            switch (state) {
                case ScanState.ready:
                    ScanRuinFunc();
                    print("ready");
                    break;
                case ScanState.scanning:
                    break;
                default:
                    break;
            }
        }
    }

    void ScanRuinFunc() {
        RaycastShot();
    }
    void RaycastShot() {
        Vector3 direction = transform.forward;
        Debug.DrawRay(transform.position, direction * range, Color.green, 2);

        int layerMask = ~(1 << 8);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, layerMask)) {
            print(hit.transform.name);
            Ruin scanObject = hit.transform.GetComponent<Ruin>();
            if (scanObject != null) {
                print("scanning");
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * range);
    }
}