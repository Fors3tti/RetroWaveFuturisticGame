using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        TakeDamage(20);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("The player is dead");
        }
    }
}
