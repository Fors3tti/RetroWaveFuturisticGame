using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite unlockedSprite;
    public int lvlToLoad;
    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        GameManager.RegisterDoor(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCol.enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();

            GameManager.ManagerLoadLevel(lvlToLoad);
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCol.enabled = true;
    }
}
