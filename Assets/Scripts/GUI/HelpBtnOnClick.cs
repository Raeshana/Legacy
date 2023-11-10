using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpBtnOnClick : MonoBehaviour
{
    public Button helpButton;
    public Sprite newSprite;
    public GameObject helpPopup;
    private Sprite oldSprite;
    public void ShowPopup() {
        Image buttonImage = helpButton.GetComponent<Image>();
        oldSprite = buttonImage.sprite;
        buttonImage.sprite = newSprite;
        helpPopup.SetActive(true);
        StartCoroutine(WaitOneSecond());
    }
    IEnumerator WaitOneSecond() {
        // Wait for 1 second
        yield return new WaitForSeconds(0.15f);
        Image buttonImage = helpButton.GetComponent<Image>();
        buttonImage.sprite = oldSprite;
    }
}
