using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueInterface : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI pnjName;
    public GameObject DialogueBox;
    public TextMeshProUGUI DialogueTag;

    public Dialogue dialogue;

    private void Awake()
    {
        DialogueBox = GameObject.FindWithTag("DialogueBox");
        DialogueTag = GameObject.FindWithTag("DialogTag").GetComponent<TextMeshProUGUI>();
        textComponent = DialogueBox.GetComponentInChildren<TextMeshProUGUI>();


        textComponent.text = string.Empty;
        DialogueBox.SetActive(false);
    }

    void Update()
    {
        if (!(textComponent.text == dialogue.text))
        {
            StopAllCoroutines();
            pnjName.text = dialogue.name;
            textComponent.text = dialogue.text;
        }
    }

    public void StartDialogue()
    {
        DialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue.text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogue.speed);
        }
    }
}
