using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class WinScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        CloseGame();
        RestartGame();
    }

    void CloseGame() {
        if (Input.GetKey(KeyCode.X)) {
            Application.Quit();
            print("Quit");
        }
    }

    void RestartGame() {
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("Scenes/Game");
            print("restart");
        }
    }
        
}
