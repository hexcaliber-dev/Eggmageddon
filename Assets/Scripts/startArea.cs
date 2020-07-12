using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class startArea : MonoBehaviour
{

    public TMP_Text startAreaText;
    public Object firstScene;
    public Sprite buttonUnpressed;
    public Sprite buttonPressed;
    private SpriteRenderer startButtonSprite;

    float currentTime;
    bool isEntering;
    string origText;
    private List<Collider2D> colliders = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        startButtonSprite = GetComponent<SpriteRenderer>();
        startButtonSprite.sprite = buttonUnpressed;
        isEntering = false;
        origText = startAreaText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Start area triggered");
        
        // isEntering = true;
        colliders.Add(other);
        startButtonSprite.sprite = buttonPressed;
        StartCoroutine(startCountdown());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Left start area");
        // isEntering = false;
        colliders.Remove(other);
        if (colliders.Count == 0) {
            startAreaText.text = origText;
            startButtonSprite.sprite = buttonUnpressed;
        }
        
    }

    private IEnumerator startCountdown()
    {
        if (colliders.Count != 0) {
            startAreaText.text="T-3";
            yield return new WaitForSeconds(1);
            if (colliders.Count != 0) {
                startAreaText.text="T-2";
                yield return new WaitForSeconds(1);
                if (colliders.Count != 0) {
                    startAreaText.text="T-1";
                    yield return new WaitForSeconds(1);
                    if (colliders.Count != 0) {
                        if (transform.name == "StartArea")
                            SceneManager.LoadScene(firstScene.name, LoadSceneMode.Single);
                        else if (transform.name == "ExitArea") {
                            Debug.Log("exiting game");
                            Application.Quit(0);
                        }
                            
                    }
                }
            }
        }

        
        

        

        

    }

}
