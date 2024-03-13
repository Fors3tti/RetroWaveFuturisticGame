using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(2, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
