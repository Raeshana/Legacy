using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitBtnOnClick : MonoBehaviour
{
    public Button quitButton;
    public Sprite newSprite;
    public void QuitGame()
    {
        Image buttonImage = quitButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        Application.Quit();
        Debug.Log("QuitBtn On Click: game quitted.");
    }
}
