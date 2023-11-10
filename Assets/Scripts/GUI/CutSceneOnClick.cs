using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneOnClick : MonoBehaviour
{
    public Sprite[] images;
    public string sceneToLoad;
    public Image imageComponent;
    private int currentIndex = 0;

    void Start() {
        imageComponent.sprite = images[currentIndex];
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (currentIndex < images.Length - 1) {
                currentIndex++;
                imageComponent.sprite = images[currentIndex];
            } else {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

}
