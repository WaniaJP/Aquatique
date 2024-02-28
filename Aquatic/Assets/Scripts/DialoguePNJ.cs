using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialoguePNJ : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public KeyCode interactKey;
    public UnityEvent InteractAction;
    private string[][] dialogue;

    class DialogueData
    {
        public string[,] MemePale { get; set; }
        public string[,] PepePale { get; set; }
        public string[,] ChefPou { get; set; }
        public string[,] CalypsoGloutentacule { get; set; }
        public string[,] ThalassinPerlefonds { get; set; }
        public string[,] EncrevaFurtiflimb { get; set; }
        public string[,] SilphydraOcéanara { get; set; }
        public string[,] NéhéridaTisselune { get; set; }
    }
    
    public float textSpeed;
    private bool isInRange;
    private bool isDialogueActive;
    private int index;
    private string characterName;
    private string characterDialogue;
    private int currentDialogindex;
    public GameObject dialoguebox;

    public void Start(){
        isInRange= false;
        isDialogueActive= false;
        textComponent.text = string.Empty;
        dialoguebox.SetActive(false);
        index= 0;
        currentDialogindex= 0;
    }

    void Update(){
        if (isDialogueActive == false){
             if (Input.GetKeyDown(interactKey)){
                if(isInRange){
                    //dialoguebox.SetActive(true);
                    string json = System.IO.File.ReadAllText("Assets/Ressource/dialogue.json");
                    Dictionary<string, List<List<string>>> jsonDictionary = JsonUtility.FromJson<Dictionary<string, List<List<string>>>>(json);
                    string cleCherchee = gameObject.tag.Trim();
                    if (jsonDictionary.ContainsKey(cleCherchee)){
                        List<List<string>> listeAssociée = jsonDictionary[cleCherchee];
                        Debug.Log(jsonDictionary[cleCherchee]);
                    }

                    //isDialogueActive = true;
                    //StartCoroutine(TypeLine());
                }
            }
        }
        else{
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)){
                if(isInRange){
                    if (textComponent.text == dialogue[currentDialogindex][index]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogue[currentDialogindex][index];
                    }
                }
            }
        }
    }

    IEnumerator TypeLine(){
        textComponent.text = string.Empty;
        if(isInRange){
            foreach (char c in dialogue[currentDialogindex][index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine(){
        if(isInRange){
            if (index < dialogue[currentDialogindex].Length - 1){
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
        }
    }

    void EndDialogue(){
        textComponent.text = string.Empty;
        isDialogueActive = false;
        dialoguebox.SetActive(false);
       //ici
    }


    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            isInRange = true;
            Debug.Log("En range du joueur!");
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            isInRange = false;
            Debug.Log("Hors range du joueur!");
        }
    }
}