using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }


    // Apply damage to player or enemy
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;

        //display health UI

        // If character has died
        if(health <= 0f)
        {
            // Play death animation
            animationScript.Death();

            // Detect the character has died
            characterDied = true;

            // If it's the player deactivate the enemy script
            if(is_Player)
            {

            }

            return;
        }

        // If enemy has taken damage
        if(!is_Player)
        {
            if(knockDown)
            {
                // If knocked down, play knock down script
                if(Random.Range(0,2) > 0)
                {
                    animationScript.KnockDown();
                }

                else
                {
                    // If not knocked down, play hit animation
                    if(Random.Range(0,3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            } // Randomized so the hit animation isn't always played or the 
              //character isn't always knocked down with the left hand, right foot, etc
        }
    }

} // class
