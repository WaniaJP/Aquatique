using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_player_esquive : MonoBehaviour
{ 

    private Player pl;
    public bool estCache;

    void Start() 
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void seCacher(Transform newPosition) {
        transform.position = newPosition.position;
        pl.RB.constraints = RigidbodyConstraints2D.FreezeAll;
        estCache = true;
    }

    public void quitterCachette() {
        transform.position = setZIndex(transform.position, -0.05f);
        estCache = false;
    }

    private Vector3 setZIndex(Vector3 vector, float z) {
        vector.z = z;
        return vector;
    }
}
