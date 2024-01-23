using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Dialogue : MonoBehaviour
{

    public bool isNext;
    private DialoguePNJ dPnj;

    void Start() 
    {
        dPnj = GameObject.FindGameObjectWithTag("DialogueBox").GetComponent<DialoguePNJ>();
    }

    void Update() {
        if (dPnj.isInRange_Encreva && Input.GetKeyDown(KeyCode.E)) {
            dPnj.dialoguebox.SetActive(true);
            dPnj.isDialogueActive = true;
            dPnj.StartCoroutine(dPnj.TypeLine());

        }
    }

    private void OnTriggerEnter2D(Collider2D entree) 
    {
           if(entree.CompareTag("Player")) {
            isNext = true;
            dPnj.isInRange_Encreva = true;
           }
    }
    
    private void OnTriggerExit2D(Collider2D sortie) 
    {
           if(sortie.CompareTag("Player")) {
            isNext = false;
            dPnj.isInRange_Encreva = false;
           }
    } 
}
