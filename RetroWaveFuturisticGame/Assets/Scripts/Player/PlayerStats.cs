using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public bool canTakeDamge = true;

    private Animator anim;
    private PlayerMoveControls playerMove;

    private Image healthUI;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        playerMove = GetComponentInParent<PlayerMoveControls>();
        //health = maxHealth;
        health = PlayerPrefs.GetFloat("HealthKey", maxHealth);

        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamge)
        {
            health -= damage;
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;

            UpdateHealthUI();

            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();

                PlayerPrefs.SetFloat("HealthKey", maxHealth);
                GameManager.ManagerRestartLevel();
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
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }

    public void IncreaseHealth(float heal)
    {
        health += heal;

        if (health > maxHealth)
            health = maxHealth;

        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health / maxHealth;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}
