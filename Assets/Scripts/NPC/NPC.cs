using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogueLines;
    public string name;

    public AudioClip audioClip;
    public AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    public override void Interact()
    {
        Dialogue.Instance.AddNewDialogue(name, dialogueLines);
        Debug.Log("Interacting with an NPC !");
        audioSource.PlayOneShot(audioClip);
    }
}
