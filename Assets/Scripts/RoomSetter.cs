using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetter : MonoBehaviour
{
  public GameObject goingTo;
    private void OnMouseDown()
    {
        goingTo.SetActive(true);
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
