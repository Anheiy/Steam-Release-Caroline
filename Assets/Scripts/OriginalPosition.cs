using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalPosition : MonoBehaviour
{
    private Vector2 originalPos;
    private OutofBounds[] allOOBs;
    private bool isOutOfBounds;
    void Start()
    {
        originalPos = this.transform.position;
        allOOBs = FindObjectsOfType<OutofBounds>();
    }

    public Vector2 getOrginalPos()
    {
        return originalPos;
    }
    public void setOriginalPos()
    {
        isOutOfBounds = false;
        foreach (OutofBounds currentOOB in allOOBs)
        {
            if (currentOOB.getOOB() == true)
            {
                isOutOfBounds = true;
            }
        }
        if (isOutOfBounds == false)
        {
            originalPos = this.transform.position;
        }
        
    }
}
