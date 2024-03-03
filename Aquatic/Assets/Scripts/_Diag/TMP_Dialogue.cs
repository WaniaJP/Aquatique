using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMP_Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject DialogueBox;
    public TextMeshProUGUI DialogueTag;

    public string nomPerso;

    public string[] lines;
    public string[] finalLines;


    public float textSpeed;

    private int index;

    [SerializeField]
    private int[] PointArret;


    [SerializeField]
    private PNJ Character;

    private void Awake()
    {
        DialogueBox = GameObject.FindWithTag("DialogueBox");
        DialogueTag = GameObject.FindWithTag("DialogTag").GetComponent<TextMeshProUGUI>();
        textComponent = DialogueBox.GetComponentInChildren<TextMeshProUGUI>();


        textComponent.text = string.Empty;
        DialogueBox.SetActive(false);
    }

    public  void Lancer()
    {
        textComponent.text = string.Empty;
        DialogueBox.SetActive(true);
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                if (Characters.GetRepeatSameDialogue(Character))
                {
                    if (textComponent.text == finalLines[index])
                    {
                        NextLine();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textComponent.text = finalLines[index];
                    }
                }
                else if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        
    }

    private void StartDialogue()
    {
        if (Characters.GetRepeatSameDialogue(Character)) {
            index = 0;
            StartCoroutine(TypeRepeatLine());

        }
        else {
            index = Characters.GetLastDiagIndex(Character);
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator TypeRepeatLine()
    {
        foreach (char c in finalLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (Characters.GetRepeatSameDialogue(Character)) { 
            
            if(index < finalLines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeRepeatLine());

            }
            else
            {
                DialogueBox.SetActive(false);
            }

        }
        else if(index < PointArret[Characters.GetPointArretIndex(Character)] - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            Characters.SetLastDiagIndex(Character, index+1);
            Characters.SetRepeatSameDialogue(Character, index == lines.Length - 1);
            Characters.SetPointArretIndex(Character, Characters.GetPointArretIndex(Character)+1);
            DialogueBox.SetActive(false);
        }
    }
}
