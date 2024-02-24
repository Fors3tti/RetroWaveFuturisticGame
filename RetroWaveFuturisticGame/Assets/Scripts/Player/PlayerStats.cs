using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public bool canTakeDamge = true;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamge)
        {
            health -= damage;
            //play hurt animation

            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();
                Debug.Log("The player is dead");
            }

            StartCoroutine(DamagePrevention());
        } 
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamge = false;
        yield return new WaitForSeconds(0.15f);
        if(health > 0)
        {
            canTakeDamge = true;
        }
        else
        {
            //play death animation
        }
    }
}
