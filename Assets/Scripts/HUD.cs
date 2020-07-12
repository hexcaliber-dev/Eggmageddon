using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public CanvasGroup pauseMenu;
    public TMP_Text remainingText, difficultyText, missileText;
    public Image muteButton;
    public Sprite muteOn, muteOff;

    public Image headwear;

    int totalEggs;

    string[] modeNames = new string[] { "OVER-EASY", "MEDIUM-WELL", "HARD-BOILED" };

    // Start is called before the first frame update
    void Start () {
        SetPause (false);
        totalEggs = GameObject.FindGameObjectsWithTag ("Egg").Length;
        headwear.sprite = GameObject.FindObjectOfType<AccessoryGenerator> ().GetCurrHat ();
        if (AudioListener.volume == 0) {
            muteButton.sprite = muteOn;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            SetPause (pauseMenu.alpha == 0f);
        }

        missileText.text = (int) (GameObject.FindObjectOfType<LaunchSystem> ().launchRate * 100) / 100 + " Seconds";

    }

    public void SetPause (bool enabled) {
        if (enabled) {
            pauseMenu.alpha = 1f;
            pauseMenu.blocksRaycasts = true;
            pauseMenu.interactable = true;
        } else {
            pauseMenu.alpha = 0f;
            pauseMenu.blocksRaycasts = false;
            pauseMenu.interactable = false;
        }
    }

    public void QuitToMenu () {
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
}