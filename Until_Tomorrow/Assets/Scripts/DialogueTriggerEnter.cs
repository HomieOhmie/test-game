using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEnter : MonoBehaviour
{
    public Dialogue dialogue;
    private Collider2D other;
    public bool alreadySeen = false;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(alreadySeen == false){
                alreadySeen = true;
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            DialogueEnd();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void DialogueEnd()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
