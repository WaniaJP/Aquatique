using UnityEngine;

public class Object : MonoBehaviour, Iinteraction, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate Guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool destroyed = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Action();
    }

    //object -> depop + ajout inventaire
    public void Action()
    {
        Destroy(gameObject);
        destroyed = true;
    }

    public void LoadData(GameData data)
    {
        data.objectDestroyed.TryGetValue(id, out destroyed);
        if(destroyed)
        {
            Action();
        }
    }

    public void SaveData(GameData data)
    {
        if(data.objectDestroyed.ContainsKey(id))
        {
            data.objectDestroyed.Remove(id);
        }
        data.objectDestroyed.Add(id, destroyed);
    }
}