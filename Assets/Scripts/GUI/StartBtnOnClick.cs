using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtnOnClick : MonoBehaviour
{
    public Button startButton;
    public Sprite newSprite;
    public string sceneToLoad;
    public void LoadScene() {
        Image buttonImage = startButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        SceneManager.LoadScene(sceneToLoad);
    }
}
