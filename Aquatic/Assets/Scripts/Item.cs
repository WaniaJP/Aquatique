using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject, Iinteraction
{

    [Header("Only Gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public enum ItemType
    {
        QuestItem,
        ConsummableItem,
        EquipementItem
    }

    public enum ActionType
    {
        Use
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Action();
    }

    //object -> depop + ajout inventaire
    public void Action()
    {
        //Destroy(gameObject);
    }

}