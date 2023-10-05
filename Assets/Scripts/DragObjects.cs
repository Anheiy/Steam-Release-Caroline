using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class DragObjects : MonoBehaviour
{

    
    private Camera mainCamera;
    //stuff to choose most appropriate object and select it
    private int currentLayer = 0;
    private int currentOrder = 0;
    //selected object
    private GameObject selectedObject;
    //the difference between the cursor and object so the object doesn't just teleport
    private Vector2 difference = Vector2.zero;

    //stuff used to find all game objects on mouse click
    private ContactFilter2D contact;
    private Collider2D[] objectsHit;
    //serialized field so we can have a private InputAction that cant be accessed elsewhere
    [SerializeField]
    private InputAction mouseClick;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    //
    private bool isDragging;
    public bool getIsDragging()
    {
        return isDragging;
    }

    
    
    private void Awake()
    {
        mainCamera = Camera.main;
        
    }
    private void OnEnable()
    {
        //when this game object is setup enable the action and when performed start the function
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }
    private void OnDisable()
    {
        //when the object is disabled disable the action
        mouseClick.performed += MousePressed;
        mouseClick.Disable();
    }

    //will run anytime the Mouse is pressed
    private void MousePressed(InputAction.CallbackContext context)
    {
        //make sure objects have been reset
        selectedObject = null;
        currentLayer = 0;
        currentOrder = 0;
        objectsHit = new Collider2D[100];


        Physics2D.OverlapPoint(mainCamera.ScreenToWorldPoint(Input.mousePosition), contact, objectsHit);
        Debug.Log(objectsHit.Length);
        foreach (Collider2D objectHit in objectsHit)
        {
            if (!objectHit) continue;
            if (objectHit.transform.gameObject.layer >= currentLayer)
            {
                if (objectHit.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder >= currentOrder)
                {
                    if (objectHit.tag == "Moveable")
                    {
                        selectedObject = objectHit.transform.gameObject;
                        currentLayer = selectedObject.layer;
                        currentOrder = selectedObject.GetComponent<SpriteRenderer>().sortingOrder;
                        difference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - selectedObject.transform.position;
                    }

                }
            }
        }
        if (objectsHit != null)
        {
            StartCoroutine(DragUpdate(selectedObject));
            Debug.Log(selectedObject);
        }


    }

    //is run until the player is no longer dragging
    private IEnumerator DragUpdate(GameObject selected)
    {
        
        while (mouseClick.ReadValue<float>() != 0)
        {

            selectedObject.transform.position = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - difference;
            isDragging = true;
            yield return waitForFixedUpdate;
        }
        isDragging = false;
        selectedObject.GetComponent<OriginalPosition>().setOriginalPos();
        
        
    }


}
