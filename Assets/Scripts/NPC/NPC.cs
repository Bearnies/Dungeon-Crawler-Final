using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogueLines;
    public string name;

    public override void Interact()
    {
        Dialogue.Instance.AddNewDialogue(name, dialogueLines);
        Debug.Log("Interacting with an NPC !");
    }
}
