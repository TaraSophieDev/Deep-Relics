using UnityEngine;
using TMPro;

public class RelicCounter : MonoBehaviour {
    
    public int counterValue = 0;
    public TMP_Text counter;

    void Update() {
        counter.text = counterValue.ToString();
    }
}
