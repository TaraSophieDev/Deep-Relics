using TMPro;
using UnityEngine;

public class SubmarineHealth : MonoBehaviour {
    public float healthValue = 100;
    //public TMP_Text health;
    public float decimalHealthValue;

    public float playerHealth;
    public TMP_Text health;


    private void Update() {
        if (playerHealth <= 0) {
            Application.Quit();
        }
    }

    private void Start() {
        UpdateHealth();
    }

    public void UpdateHealth() {
        health.text = playerHealth.ToString("0");
        health.text += "%";
    }
}
