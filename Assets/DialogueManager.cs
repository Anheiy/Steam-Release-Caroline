using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private List<string> Dialogue = new List<string>();
    public InputAction mouseClick;
    private TextMeshProUGUI uiText;
    private GameObject dialoguePanel;
    private int dialogueOn = 0;
    private RoomSetter[] roomSetters;
    private void Start()
    {
        uiText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        dialoguePanel = GameObject.Find("DialoguePanel");
        roomSetters = GameObject.FindObjectsOfType<RoomSetter>();
        string[] s = { "1", "2", "3"};
        AddDialogue(s);
    }
    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += DisplayDialogue;
    }
    private void OnDisable()
    {
        mouseClick.performed += DisplayDialogue;
        mouseClick.Disable();
    }
    public void AddDialogue(string[] dialogueString)
    {
        foreach (string dialogue in dialogueString)
        {
            Dialogue.Add(dialogue);
        }
        uiText.text = Dialogue[dialogueOn];
        dialogueOn++;
        dialoguePanel.SetActive(true);
        //enable other clicks
        GameObject.Find("Manager").GetComponent<DragObjects>().enabled = false;
        foreach(RoomSetter rs in roomSetters)
        {
            rs.enabled = false;
        }
    }

    public void DisplayDialogue(InputAction.CallbackContext context)
    {
        if(dialogueOn != Dialogue.Count)
        {
            uiText.text = Dialogue[dialogueOn];
            dialogueOn++;
        }
        else
        {
            CloseDialogue();
        }
    }

    public void CloseDialogue()
    {
        Dialogue.Clear();
        dialogueOn = 0;
        dialoguePanel.SetActive(false);
        //enable other clicks
        GameObject.Find("Manager").GetComponent<DragObjects>().enabled = true;
        foreach (RoomSetter rs in roomSetters)
        {
            rs.enabled = true;
        }
    }


}
