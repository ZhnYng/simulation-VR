using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    public GameObject popupPanel;
    public void OpenPopoup()
    {
        popupPanel.SetActive(true);
    }

    public void ClosePopoup()
    {
        popupPanel.SetActive(false);
    }
}
