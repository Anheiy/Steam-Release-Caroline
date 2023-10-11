using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOrder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "Moveable")
        {
            Debug.Log(collision.gameObject);
            Debug.Log(this.gameObject.transform.parent.gameObject);
            if (collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder <= this.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = this.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
                Debug.Log("Got inside");
            }
            

        }
    }
}
