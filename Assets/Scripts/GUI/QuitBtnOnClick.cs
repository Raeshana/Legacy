using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuitBtnOnClick : MonoBehaviour
{
    public Button quitButton;
    public Sprite newSprite;
    public Color newColor;
    public void QuitGame()
    {
        Image buttonImage = quitButton.GetComponent<Image>();
        buttonImage.sprite = newSprite;
        Application.Quit();
        Debug.Log("QuitBtn On Click: game quitted.");
    }
}
