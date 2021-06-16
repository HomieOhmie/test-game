using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;
    
    public string changeScene;
    

    private Queue<string> textLines;
    void Start()
    {
        if(!dialogueBox.activeInHierarchy){
            dialogueBox.SetActive(true);
        }
        textLines = new Queue<string>();
        StartDialogue(dialogue);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(changeScene);
    }

    private IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }
}
