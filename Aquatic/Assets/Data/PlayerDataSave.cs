using UnityEngine;

[System.Serializable]
public class PlayerDataSave
{

    public float[] position;

    public PlayerDataSave(Player player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
