using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    private Collider2D other;
    public bool playerInRange;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
            other = this.other;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            playerInRange = false;
            //Debug.Log("Player has left the range!");
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            cam.minPosition.x = cameraMinChange.x;
            cam.minPosition.y = cameraMinChange.y;
            cam.maxPosition.x = cameraMaxChange.x;
            cam.maxPosition.y = cameraMaxChange.y;
            other.transform.position += playerChange;  
            GetComponent<AudioSource>().Play();
            if(needText){
                StartCoroutine(placeNameCo());
            }
        }
        }
    }
    
    // Runs paralell to other processes and let's you place specific wait Time
    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}