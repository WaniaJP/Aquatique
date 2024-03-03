
using System;
using System.Linq;
[Serializable]
public class Speaker
{
    public int id;
    public string name;

    public Speaker(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public int GetId()
    {
        return id;
    }


    public string GetName()
    {
        return name;
    }


    public Dialogue GetDialogue()
    {
        DialogueFact tmp = DialogueFactManager.instance.dialogues.Where(d => d.CouldBeDone() && d.speakerId == id)
            .FirstOrDefault();

        if(tmp != null)
        {
            tmp.SetDone();
        }
        return tmp == null ? new Dialogue(name, "Je suis occupée") : new Dialogue(name, tmp.text);
    }
}


public struct Dialogue
{
    public string name;
    public string text;
    public float speed;

    public Dialogue(string name, string text)
    {
        this.name = name;
        this.text = text;
        speed = 1.0f;
    }
}