using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBtnOnClick : MonoBehaviour
{
    public GameObject helpPopup;
    // Start is called before the first frame update
    public void HidePopup()
    {
        helpPopup.SetActive(false);
    }
}
