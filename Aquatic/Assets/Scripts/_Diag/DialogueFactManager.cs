
using System.ComponentModel.Design;
using UnityEngine;

public class DialogueFactManager : MonoBehaviour
{
    public static DialogueFactManager instance;
    public DialogueFact[] dialogues;
    public Speaker[] speakers;

    public static DialogueInterface ui;

    private void Awake()
    {
        if (instance == null)
        {
            SaveData.LoadFromJson();
            dialogues = SaveData.bd.dialogueFacts;
            speakers = SaveData.bd.speakers;
            instance = this;
        }

        if (dialogues == null)
        {
            dialogues = new DialogueFact[0];
        }

        if (speakers == null)
        {
            speakers = new Speaker[0];
        }
    }




}