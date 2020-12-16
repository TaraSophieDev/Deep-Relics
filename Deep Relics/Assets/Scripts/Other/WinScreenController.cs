using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    
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
