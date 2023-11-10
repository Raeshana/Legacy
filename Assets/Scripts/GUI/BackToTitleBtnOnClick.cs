using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToTitleBtnOnClick : MonoBehaviour {
    public Button backToTitleButton;
    public Sprite newSprite;
    public string sceneToLoad;
    public void LoadScene() {
        Image buttonImage = backToTitleButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        SceneManager.LoadScene(sceneToLoad);
    }
}

