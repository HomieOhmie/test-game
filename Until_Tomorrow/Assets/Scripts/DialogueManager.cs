using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;
    public bool startUp;

    private Queue<string> textLines; // why not public?
    // Start is called before the first frame update
    void Start()
    {
        if(dialogueBox.activeInHierarchy && startUp == false){
            dialogueBox.SetActive(false);
        }
        textLines = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        textLines.Clear();

        foreach(string textLine in dialogue.lines){
            textLines.Enqueue(textLine);
        }

        dialogueBox.SetActive(true);
        DisplayNextTextLine();
    }

    public void DisplayNextTextLine(){
        if(textLines.Count == 0){
            EndDialogue();
            return;
        }

        string textLine = textLines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(textLine));
    }

    public void EndDialogue(){
        dialogueBox.SetActive(false);
    }

    private IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }
}
