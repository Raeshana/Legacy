using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneLoader : MonoBehaviour
{
    public GameObject uiElementsToHide;

    void Start() {
        uiElementsToHide.SetActive(false);
    }
}
