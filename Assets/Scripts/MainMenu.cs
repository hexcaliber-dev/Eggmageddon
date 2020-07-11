using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenu : MonoBehaviour {

    public Image eggBG;
    public RectTransform eggImg1;
    public RectTransform eggImg2;
    public GameObject startArea;
    public GameObject exitArea;
    public GameObject player;
    public Object firstScene;
    private float previousVolume;
    enum state {start, quit, muteBG, muteFX};
    // Begin game
        // Difficulty


    void Start() {
        
    }

    void Update() {
        eggImg1.Rotate(Vector3.right * Time.deltaTime * 10);
        eggImg2.Rotate(Vector3.left * Time.deltaTime * 10);
        startArea.transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        exitArea.transform.Rotate(Vector3.forward * -1 * Time.deltaTime * 100);
        if (Vector3.Distance(player.transform.position, startArea.transform.position) < 1f) {
            Debug.Log("on start");
        }
    }

    void OnMouseUp() {
        
    }


    public void startGame() {
        StartCoroutine(initStartTransition(
            eggBG, 
            new Color(eggBG.color.r, eggBG.color.g, eggBG.color.b, 0f), 
            new Color(eggBG.color.r, eggBG.color.g, eggBG.color.b, 1f), 
            3f,
            firstScene)
        );
    }


    public void exitGame(int exitCode = 0) {
        // Maybe egg cracking animation or smth lol
        Debug.Log("exiting game");
        Application.Quit(exitCode);
    }


    private IEnumerator initStartTransition(Image image, Color from, Color to, float duration, Object scene)
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
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
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
