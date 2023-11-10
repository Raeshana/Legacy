using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueBtnOnClick : MonoBehaviour {
    public Button continueButton;
    public Sprite newSprite;
    public string sceneToLoad;
    public void LoadScene() {
        Image buttonImage = continueButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        SceneManager.LoadScene(sceneToLoad);
    }
}


