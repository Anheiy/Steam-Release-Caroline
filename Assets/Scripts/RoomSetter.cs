using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetter : MonoBehaviour
{
  public GameObject goingTo;
    private bool canSwitch = false;
    private void OnEnable()
    {
        canSwitch = true;
    }
    private void OnDisable()
    {
        canSwitch = false;
    }
    private void OnMouseDown()
    {
        if (canSwitch)
        {
            goingTo.SetActive(true);
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
