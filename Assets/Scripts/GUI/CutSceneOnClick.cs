using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneManager : MonoBehaviour {

    // for access of paragraphCheck in CustSceneAudioBehavior
    public static CutsceneManager Instance;
    public TextMeshProUGUI textElement;
    //For safety
    public float typingDefaultSpeed = 0.01f;
    public float typingSpeed;

    public List<string> paragraphs;
    public string sceneToLoad;

    private int currentParagraphIndex = 0;
    private bool paragraphCompleted = false; // Flag to track when a paragraph is complete

    // so audio can access
    public bool paragraphCheck;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
        //For saftey
        typingSpeed = typingDefaultSpeed;


    }

    void Start() {
        StartCoroutine(PlayCutscene());
        AudioSource Click = gameObject.AddComponent<AudioSource>();
        Click.playOnAwake = false;


    }

void Update() {
        // Check for mouse click to progress to the next paragraph
        if (paragraphCompleted && Input.GetMouseButtonDown(0)) {
            paragraphCompleted = false; // Reset the flag
        }
        paragraphCheck = paragraphCompleted;

    }

    IEnumerator PlayCutscene() {
        // Initialize text and paragraph
        textElement.text = "";
        currentParagraphIndex = 0;

        while (currentParagraphIndex < paragraphs.Count) {
            yield return StartCoroutine(TypeText(paragraphs[currentParagraphIndex]));
            paragraphCompleted = true; // Mark the paragraph as complete
            yield return new WaitUntil(() => !paragraphCompleted); // Wait for the mouse click

            // Add a pause here if needed
            NextParagraph();
        }

        // Cutscene is finished; you can trigger the next event here.
    }

    IEnumerator TypeText(string text) {
        for (int i = 0; i < text.Length; i++) {
            textElement.text = text.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void NextParagraph() {
        currentParagraphIndex++;
        if (currentParagraphIndex < paragraphs.Count) {
            textElement.text = ""; // Clear the text for the next paragraph
        } else {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
