using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds() {
        yield return new WaitForSeconds(0.1f);
        helpPopup.SetActive(true);
        Image buttonImage = helpButton.GetComponent<Image>();
        buttonImage.sprite = oldSprite;
    }
}
