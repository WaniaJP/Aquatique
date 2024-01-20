using TMPro;
using UnityEngine;

public class Png : MonoBehaviour, Iinteraction
{
    [SerializeField] private string dialogs = "Bonjour monsieur";
    [SerializeField] private TMP_Text text;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Action();
    }

    //object -> activer dialogues
    public void Action()
    {
        text.text = dialogs;
        text.enabled = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            text.enabled = false;
    }
}
