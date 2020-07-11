using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    enum state {start, quit, muteBG, muteFX};
    // Begin game
        // Difficulty
    void Start() {

    }

    void OnMouseUp() {
        
    }

    public void startGame() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void exitGame(int exitCode = 0) {
        // Maybe egg cracking animation or smth lol
        Debug.Log("exiting game");
        Application.Quit(exitCode);
    }

//     Mute music/sfx corner button

//     Quit game
}
