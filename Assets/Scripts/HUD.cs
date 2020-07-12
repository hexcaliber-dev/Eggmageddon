using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public CanvasGroup pauseMenu, endMenu;
    public TMP_Text remainingText, difficultyText, missileText;
    public Image muteButton;
    public Sprite muteOn, muteOff;

    public Image headwear;

    int totalEggs;

    string[] modeNames = new string[] { "OVER-EASY", "MEDIUM-WELL", "HARD-BOILED" };

    bool initialized = false;

    // Start is called before the first frame update
    void Start () {
        SetPause (false);
        StartCoroutine (DelayedStart ());
    }

    IEnumerator DelayedStart () {
        yield return new WaitForSeconds (0.5f);
        totalEggs = GameObject.FindGameObjectsWithTag ("Egg").Length;
        UpdateRemainingEggs (totalEggs);
        print (GameObject.FindObjectOfType<Player> ());
        headwear.sprite = GameObject.FindObjectOfType<Player> ().accessories.GetCurrHat ();
        if (AudioListener.volume == 0) {
            muteButton.sprite = muteOn;
        }
        initialized = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            SetPause (pauseMenu.alpha == 0f);
        }

        if (initialized)
            missileText.text = (int) (GameObject.FindObjectOfType<LaunchSystem> ().launchRate * 100) / 100 + " Seconds";

    }

    public void SetPause (bool enabled) {
        if (enabled) {
            Time.timeScale = 0f;
            pauseMenu.alpha = 1f;
            pauseMenu.blocksRaycasts = true;
            pauseMenu.interactable = true;
        } else {
            Time.timeScale = 1f;
            pauseMenu.alpha = 0f;
            pauseMenu.blocksRaycasts = false;
            pauseMenu.interactable = false;
        }
    }

    public void QuitToMenu () {
        Time.timeScale = 1f;
        SceneManager.LoadScene ("MainMenu");
    }

    public void toggleMute () {
        if (AudioListener.volume != 0) {
            AudioListener.volume = 0;
            muteButton.sprite = muteOn;
        } else {
            AudioListener.volume = 1f;
            muteButton.sprite = muteOff;
        }
    }

    public void UpdateRemainingEggs (int remaining) {
        remainingText.text = remaining + " OF " + totalEggs + " EGGS LEFT";
    }

    public void ShowEndgame () {
        endMenu.alpha = 1f;
        endMenu.blocksRaycasts = true;
        endMenu.interactable = true;
        GameObject.FindObjectOfType<CameraInit>().EndgameZoom();
    }

    public void ReloadLevel () {
        SceneManager.LoadScene ("FinalTest");
    }
}