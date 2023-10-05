using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private DragObjects drag;
    private bool OOB;
    private void Start()
    {
        drag = GameObject.Find("Manager").GetComponent<DragObjects>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OOB = true;
        if(drag.getIsDragging() == false)
        {
            collision.gameObject.transform.position = collision.gameObject.GetComponent<OriginalPosition>().getOrginalPos();
            OOB = false;
        }
    }

    public bool getOOB()
    {
        return OOB;
    }
}
