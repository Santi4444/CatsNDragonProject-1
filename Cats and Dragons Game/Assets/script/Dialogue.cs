using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text conversation;

    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Triggering Player Interact - When Entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        index = 0;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("tEST");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueText.gameObject.SetActive(true);
        }
    }

    //Triggering Player Interact - When Exited
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("tEST");
        }
    }

    /*
    IEnumerator TypeLine()
    {

    }
    */
}
