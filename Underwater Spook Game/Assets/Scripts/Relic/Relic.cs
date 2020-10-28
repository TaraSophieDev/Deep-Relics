using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class Relic : MonoBehaviour {
    
    public  RelicCounter relicCounter;

    private bool isComplete = false;
    
    public int randMin = 5;
    public int randMax = 10;

    public GameObject light;
    private float scanTime;
    public float currentScanTime = 0.1f;

    public relicState state = relicState.unscanned;
    public enum relicState {
        unscanned,
        beingScanned,
        incompleteScan,
        completeScan
    }

    private void Update() {
        switch (state) {
            case relicState.unscanned:
                print("unscanned");
                break;
            case relicState.beingScanned:
                print("being scanned");
                break;
            case relicState.incompleteScan:
                resetTime();
                print("incomplete");
                state = relicState.unscanned;
                break;
            case relicState.completeScan:
                isComplete = true;
                print("complete");
                light.SetActive(false);
                //relicCounter.AddRelicCounterValue();
                relicCounter.counterValue++;
                break;
        }

        if (state != relicState.completeScan && !isComplete) {
            if (currentScanTime == 0 && !isComplete) {
                state = relicState.completeScan;
            }
            else if (currentScanTime > 0.0f && Input.GetKeyDown("f")) {
                print("epic gamer moment");
                state = relicState.beingScanned;
            }
            else if (currentScanTime > 0.0f && Input.GetKeyUp("f")) {
                state = relicState.incompleteScan;
            }
            else {
                state = relicState.unscanned;
            }
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
        state = relicState.beingScanned;
        if (currentScanTime > 0) {
            currentScanTime -= TickDownAmount;
        }
        else {
            //state = relicState.completeScan;
        }
        currentScanTime = Mathf.Clamp(currentScanTime, 0, scanTime);
    }
}
