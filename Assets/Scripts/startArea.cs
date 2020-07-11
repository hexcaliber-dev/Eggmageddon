using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class startArea : MonoBehaviour
{

    public TMP_Text startAreaText;
    public Object firstScene;
    float currentTime;
    bool isEntering;
    string origText;
    // Start is called before the first frame update
    void Start()
    {
        isEntering = false;
        origText = startAreaText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Start area triggered");
        
        isEntering = true;
        StartCoroutine(startCountdown());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Left start area");
        isEntering = false;
        startAreaText.text = origText;
    }

    private IEnumerator startCountdown()
    {
        if (isEntering) {
            startAreaText.text="3";
            yield return new WaitForSeconds(1);
        }
        
        if (isEntering) {
            startAreaText.text="2";
            yield return new WaitForSeconds(1);
        }

        if (isEntering) {
            startAreaText.text="1";
            yield return new WaitForSeconds(1);
        }

        if (isEntering) {
            if (transform.name == "StartArea")
                SceneManager.LoadScene(firstScene.name, LoadSceneMode.Single);
            else if (transform.name == "ExitArea") {
                Debug.Log("exiting game");
                Application.Quit(0);
            }
                
        }

    }

}
