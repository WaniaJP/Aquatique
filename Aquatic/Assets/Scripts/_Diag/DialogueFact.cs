
using JetBrains.Annotations;
using System;
using System.Linq;

[Serializable]
public class DialogueFact : Fact
{
    public int idTexte;
    public int speakerId;
    public string text;
    public bool done;

    public int criteria;


    public DialogueFact(string id, string name, int value, int texteId, int speaker, string texte, int criteria) : base(id, name, value)
    {
        this.speakerId = speaker;
        this.text = texte;
        this.done = false;
        this.idTexte = texteId;
        this.criteria = criteria;
    }

    public bool CouldBeDone()
    {
        CriteriaFact critere = SaveData.bd.criteriaFacts.FirstOrDefault(c => c.id == criteria);
        return critere == null ? !done : critere.DoesItMeet() && !done;
    }

    public void SetDone()
    {
        done = true;
    }
}