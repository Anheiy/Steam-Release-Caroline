using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject NotepadUI;

    public void TurnOffUI()
    {
        MainUI.SetActive(true);
        NotepadUI.SetActive(false);
    }

    public void NotepadOpen()
    {
        MainUI.SetActive(false);
        NotepadUI.SetActive(true);
    }

}
