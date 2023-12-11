using UnityEngine;

public class Object : MonoBehaviour, Iinteraction
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Action();
    }

    //object -> depop + ajout inventaire
    public void Action()
    {
        Destroy(gameObject);
    }
}