using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    private GatherInput gatherInput;
    private PlayerMoveControls playerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gatherInput = collision.GetComponent<GatherInput>();
        playerMove = collision.GetComponent<PlayerMoveControls>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gatherInput.tryToClimb)
        {
            playerMove.onLadders = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMove.ExitLadders();
    }
}
