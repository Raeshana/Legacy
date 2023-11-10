using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryBtnOnClick : MonoBehaviour {
    public Button retryButton;
    public Sprite newSprite;
    public string sceneToLoad;
    public void LoadScene() {
        Image buttonImage = retryButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        SceneManager.LoadScene(sceneToLoad);
    }
}
