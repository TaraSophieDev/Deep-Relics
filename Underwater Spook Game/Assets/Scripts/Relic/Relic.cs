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
        //This switch state is pure pile of garbage
        //If you have a better solution for not destroying the relic and just turn off the light without the counter going crazy pls fix 🙏
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
                //Destroy(gameObject);
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
            else if (!isComplete && currentScanTime > 0 && Input.GetKeyDown("f")) {
                print("epic gamer moment");
                state = relicState.beingScanned;
            }
            else if (currentScanTime > 0 && Input.GetKeyUp("f")) {
                state = relicState.incompleteScan;
            }
            else {
                //state = relicState.unscanned;
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
            //Thx Jax ❤
            Destroy(gameObject);
            relicCounter.counterValue++;
        }
        currentScanTime = Mathf.Clamp(currentScanTime, 0, scanTime);
    }
}
