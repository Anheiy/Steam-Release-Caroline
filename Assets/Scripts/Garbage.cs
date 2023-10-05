using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    private DragObjects drag;
    private CompletionManager CompletionManager;
    
    private void Start()
    {
        drag = GameObject.Find("Manager").GetComponent<DragObjects>();
        CompletionManager = GameObject.Find("Manager").GetComponent<CompletionManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Moveable")
        {
            
            if (drag.getIsDragging() == false)
            {
                Destroy(collision.gameObject);
                CompletionManager.ProgressionBarUpdate();
            }
        }
    }
}
