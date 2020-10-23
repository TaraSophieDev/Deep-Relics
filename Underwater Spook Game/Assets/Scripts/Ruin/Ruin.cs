using UnityEngine;
using Random = UnityEngine.Random;

public class Ruin : MonoBehaviour {
    public int randMin = 5;
    public int randMax = 10;

    private float scanTime;
    public float currentScanTime;

    public ruinState state = ruinState.unscanned;
    public enum ruinState {
        unscanned,
        beingScanned,
        incompleteScan,
        completeScan
    }

    private void Update() {
        switch (state) {
            case ruinState.unscanned:
                print("unscanned");
                break;
            case ruinState.beingScanned:
                print("being scanned");
                break;
            case ruinState.incompleteScan:
                resetTime();
                print("incomplete");
                break;
            case ruinState.completeScan:
                print("complete");
                break;
        }
        if (Input.GetKeyDown("f")) {
            state = ruinState.beingScanned;
        }
        else if (currentScanTime > 0 && (Input.GetKeyUp("f"))) {
            state = ruinState.incompleteScan;
        }
        else if (currentScanTime == 0 ) {
            state = ruinState.completeScan;
        }
        else {
            state = ruinState.unscanned;
        }
    }

    private void Start() {
        GetRandomScanTime();
    }

    public void resetTime() {
        currentScanTime = scanTime;
    }

    private void GetRandomScanTime() {
       scanTime = Random.Range(randMin, randMax);
       currentScanTime = scanTime;
    }
    
    public void ScanTickDown(float TickDownAmount) {
        state = ruinState.beingScanned;
        if (currentScanTime > 0) {
            currentScanTime -= TickDownAmount;
        }
        else {
            print("finished");
        }
        currentScanTime = Mathf.Clamp(currentScanTime, 0, scanTime);
    }
}
