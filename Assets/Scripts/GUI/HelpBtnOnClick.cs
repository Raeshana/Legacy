using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBtnOnClick : MonoBehaviour
{
    public GameObject helpPopup;
    public void ShowPopup() {
        helpPopup.SetActive(true);
    }
}
