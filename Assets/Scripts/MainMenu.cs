using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenu : MonoBehaviour {

    public Image eggBG;
    public Object firstScene;
    private float previousVolume;
    enum state {start, quit, muteBG, muteFX};
    // Begin game
        // Difficulty


    void Start() {
        
    }


    void OnMouseUp() {
        
    }


    public void startGame() {
        StartCoroutine(initStartTransition(
            eggBG, 
            new Color(eggBG.color.r, eggBG.color.g, eggBG.color.b, 0f), 
            new Color(eggBG.color.r, eggBG.color.g, eggBG.color.b, 1f), 
            3f)
        );
    }


    public void exitGame(int exitCode = 0) {
        // Maybe egg cracking animation or smth lol
        Debug.Log("exiting game");
        Application.Quit(exitCode);
    }


    private IEnumerator initStartTransition(Image image, Color from, Color to, float duration)
    {
        float timeElapsed = 0.0f;
        
        float t = 0.0f;
        while(t < 1.0f)
        {
            timeElapsed += Time.deltaTime;

            t = timeElapsed / duration;

            image.color = Color.Lerp(from, to, t);
            
            yield return null;
        }
        SceneManager.LoadScene(firstScene.name, LoadSceneMode.Single);
    }

    //     Mute music/sfx corner button
    public void toggleMute() {
        if (AudioListener.volume != 0) {
            previousVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else {
            AudioListener.volume = previousVolume; 
        }
        Debug.Log("Volume is now: " + AudioListener.volume);
    }


    //     Quit game
}
