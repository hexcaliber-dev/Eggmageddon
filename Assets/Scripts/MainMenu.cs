using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Image eggBG;
    public GameObject eggImg1;
    public GameObject eggImg2;
    public GameObject startAreaEasy;
    public GameObject startAreaMed;
    public GameObject startAreaHard;

    public GameObject exitArea;
    public GameObject player;
    public GameObject logo;
    public GameObject launchOrder;

    public Image muteButton;
    public Sprite muteOn, muteOff;

    // public GameObject player2;
    // public GameObject player3;
    // public GameObject player4;
    // public GameObject player5;
    // public GameObject player6;
    private int totalPlayerCt = 1;
    public Object firstScene;
    private float previousVolume;
    private RawImage logo_raw;

    enum state { start, quit, muteBG, muteFX }
    // Begin game
    // Difficulty
    private GameObject[] players;
    private int currentAnimated = 0;
    void Start () {
        // players = new GameObject[6]{player, player2, player3, player4, player5, player6};
        players = new GameObject[1] { player };
        logo_raw = logo.GetComponent<RawImage> ();

        StartCoroutine (initStartAnimation (logo, Screen.height - Screen.height / 4));
        StartCoroutine (initStartAnimation (eggImg1, Screen.height - Screen.height / 4));
        StartCoroutine (initStartAnimation (eggImg2, Screen.height - Screen.height / 4));
        StartCoroutine (initStartAnimation (launchOrder, Screen.height - Screen.height / 2));
        // StartCoroutine (initStartAnimation (logo, 1000f));
        // StartCoroutine (initStartAnimation (eggImg1, 1000f));
        // StartCoroutine (initStartAnimation (eggImg2, 1000f));
        StartCoroutine (initStartAnimation (startAreaEasy, -2.54f));
        StartCoroutine (initStartAnimation (startAreaMed, -2.54f));
        StartCoroutine (initStartAnimation (startAreaHard, -2.54f));

        StartCoroutine (initStartAnimation (exitArea, -2.54f));
        StartCoroutine (initStartAnimation (players[currentAnimated], -0.334f));
    }

    void Update () {
        // eggImg1.Rotate (Vector3.right * Time.deltaTime * 10);
        // eggImg2.Rotate (Vector3.left * Time.deltaTime * 10);

        // logo.transform.Rotate (Vector3.left * Time.deltaTime * 10);

        // startArea.transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        exitArea.transform.Rotate (Vector3.forward * -1 * Time.deltaTime * 100);
        // if (Vector3.Distance (player.transform.position, startArea.transform.position) < 1f) {
        //     Debug.Log ("on start");
        // }

    }

    void OnMouseUp () {

    }

    public void startGame () {
        StartCoroutine (initStartTransition (
            eggBG,
            new Color (eggBG.color.r, eggBG.color.g, eggBG.color.b, 0f),
            new Color (eggBG.color.r, eggBG.color.g, eggBG.color.b, 1f),
            3f,
            firstScene));
    }

    public void exitGame (int exitCode = 0) {
        // Maybe egg cracking animation or smth lol
        Debug.Log ("exiting game");
        Application.Quit (exitCode);
    }

    private IEnumerator initStartTransition (Image image, Color from, Color to, float duration, Object scene) {
        float timeElapsed = 0.0f;

        float t = 0.0f;
        while (t < 1.0f) {
            timeElapsed += Time.deltaTime;

            t = timeElapsed / duration;

            image.color = Color.Lerp (from, to, t);

            yield return null;
        }
        SceneManager.LoadScene (scene.name, LoadSceneMode.Single);
    }

    private IEnumerator initStartAnimation (GameObject playerIn, float newPosY) {
        float timeElapsed = 0.0f;
        float duration = 3f;
        float t = 0.0f;
        Vector3 origPos = playerIn.transform.position;
        Vector3 newPos = playerIn.transform.position;
        newPos.y = newPosY;

        while (t < 1.0f) {
            timeElapsed += Time.deltaTime;

            // t = timeElapsed / duration;
            t = Mathf.Clamp01 (timeElapsed / duration);
            playerIn.transform.position = Vector3.Lerp (origPos, newPos, t);
            yield return null;
        }
        // if (currentAnimated < totalPlayerCt - 1) {
        //     currentAnimated++;
        //     StartCoroutine (initStartAnimation (players[currentAnimated], -0.334f));
        // }

    }

    //     Mute music/sfx corner button

    public void toggleMute () {
        if (AudioListener.volume != 0) {
            AudioListener.volume = 0;
            muteButton.sprite = muteOn;
        } else {
            AudioListener.volume = 1f;
            muteButton.sprite = muteOff;
        }
    }

    //     Quit game
}