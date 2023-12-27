using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCharacterBehavior : MonoBehaviour // manage the collision between the player and the different objects, using an observer pattern
{
    // Start is called before the first frame update
    void Start() {}

    /// <summary>
    /// Called when a 2D collider enters this object's trigger collider.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Coin")) 
        {
            print("Coin collected");
            Score.IncreaseScore(1);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Finish"))
        {
            print("Game finished");
            pauseSystem.isGameFinished = true;
        }
        if(other.CompareTag("Respawn"))
        {
            print("Player died");
            pauseSystem.isGameFailed = true;
        }
        
    }
}
