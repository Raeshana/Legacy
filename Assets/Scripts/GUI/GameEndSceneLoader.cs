using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndSceneLoader : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Win", 0) == 0) {
            loseScreen.SetActive(true);
            winScreen.SetActive(false);
        } else {
            loseScreen.SetActive(false);
            winScreen.SetActive(true);
        }
    }
}
