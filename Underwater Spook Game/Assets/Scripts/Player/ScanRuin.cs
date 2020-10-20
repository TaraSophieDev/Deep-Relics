using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
            RuinScanner();
        }
        /*if (Input.GetKeyDown("f")) {
            switch (state) {
                case ScanState.ready:
                    ScanRuinFunc();
                    break;
                case ScanState.scanning:
                    break;
                default:
                    break;
            }
        }*/
    }

    void RuinScanner() {
        Vector3 direction = transform.forward;
        Debug.DrawRay(transform.position, direction * range, Color.green, 2);

        int layerMask = ~(1 << 8);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, layerMask)) {
            print(hit.transform.name);
            //just works in the if statement
            if (hit.transform.TryGetComponent<Ruin>(out Ruin ruin)) {
                ruin.ScanTickDown(Time.deltaTime);
                //print("scanTime: " + ruin.scanTime);
                print("currentScanTime: " +  ruin.currentScanTime);
            }
        }
        else {
            print("No scannable Object");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * range);
    }
}