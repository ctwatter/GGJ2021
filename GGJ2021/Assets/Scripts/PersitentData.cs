using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PersitentData : MonoBehaviour
{
    private static PersitentData _instance;
    public static PersitentData Instance { get { return _instance; } }

    public CanvasGroup loadScreen;
    public GameObject tutorialUI;
    public GameObject inputHandler;
    public TextMeshProUGUI globalTimer;
    public float globalTimeLeft;
    public bool start = false;
    public bool waitingForInput = false;
    public int outcome = -1;

    public int successes;
    public int failures;

    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {

        globalTimeLeft -= Time.deltaTime;
        var cleanGlobalTimer =  Mathf.Ceil(globalTimeLeft);
        globalTimer.text = "" + cleanGlobalTimer;
        if(globalTimeLeft <= 0)
        {
            //load end scene
        }

    }

    public void LoadScene(int _scene)
    {
        StartCoroutine(Transition(_scene));
    }

    public void displayOutcome(int _outcome)
    {
        if(_outcome == 1){
            //show check sprite
            successes++;
        } 
        else if (_outcome == -1)
        {
            //show x sprite
            failures++;
        }
    }

    IEnumerator Transition(int _scene) 
    {
        yield return StartCoroutine(FadeInScreen(0.5f));
        displayOutcome(outcome);
        outcome = -1;
        SceneManager.LoadScene(_scene);
    
        yield return StartCoroutine(FadeOutScreen(1));
        waitingForInput = true;
    }



    public void StartMinigame()
    {
        tutorialUI = GameObject.FindGameObjectWithTag("tutorialUI");
        tutorialUI.SetActive(false);
        inputHandler = GameObject.FindGameObjectWithTag("inputHandler");
        inputHandler.SetActive(true);
        //enable input manager or something?

    }
    

    IEnumerator FadeInScreen(float duration)
    {
        float startValue = loadScreen.alpha;
        float time = 0;

        while (time < duration)
        {
            loadScreen.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        loadScreen.alpha = 1;
    }

    IEnumerator FadeOutScreen(float duration)
    {
        float startValue = loadScreen.alpha;
        float time = 0;

        while (time < duration)
        {
            loadScreen.alpha = Mathf.Lerp(startValue, 0, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        loadScreen.alpha = 0;
    }

    void OnStartMinigame()
    {
        if(waitingForInput)
        {
            StartMinigame();
            waitingForInput = false;
        }
        
    }
    
}
