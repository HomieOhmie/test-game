using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endBox;
    private Collider2D other;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            StartCoroutine(endGame());
        }
    }

    private IEnumerator endGame(){
        endBox.SetActive(true);
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }
}
