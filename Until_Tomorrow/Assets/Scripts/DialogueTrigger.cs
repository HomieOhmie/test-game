using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private Collider2D other;
    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
            if(Input.GetKeyDown(KeyCode.E)){
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            playerInRange = false;
            DialogueEnd();
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.E) && playerInRange){
                    TriggerDialogue();
            }
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
