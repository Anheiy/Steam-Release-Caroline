using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompletionManager : MonoBehaviour
{
    public Image progressionBar;
    public TextMeshProUGUI progBarText;
    public TextMeshProUGUI garbageLeft;
    private float garbageVal;
    private float startingGarbageVal;
    private void Start()
    {
        startingGarbageVal = GameObject.FindGameObjectsWithTag("Moveable").Length;
        ProgressionBarUpdate();
    }
    public void ProgressionBarUpdate()
    {
        garbageVal = GameObject.FindGameObjectsWithTag("Moveable").Length;
        //Debug.Log(startingGarbageVal);
        //Debug.Log(garbageVal);
        garbageLeft.text = garbageVal.ToString();
        progressionBar.fillAmount = 1 - garbageVal / startingGarbageVal;
        progBarText.text = Mathf.Round((1 - garbageVal / startingGarbageVal ) * 100)  + "%";
    }

    private void Update()
    {
        ProgressionBarUpdate();
    }
}
