using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health, maxHealth;

    [SerializeField]
    private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
     //TESTS AUGMENTER/BAISSER LA SANTE
    void Update()
    {
        if(Input.GetKeyDown("y")) {
            setHealth(-20f);
            
        }
        if(Input.GetKeyDown("h")) {
            setHealth(20f);
            
        }
    }

    public void setHealth(float healthChange) {
        health += healthChange;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.setHealth(health);
    }
}
