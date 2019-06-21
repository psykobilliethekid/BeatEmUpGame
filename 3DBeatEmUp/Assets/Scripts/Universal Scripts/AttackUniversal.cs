using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_Prefab;


    void Update()
    {
        DetectCollision();
    }


    // Detects if the Player or Enemy hits
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        // If there is a hit
        if(hit.Length > 0)
        {
           // If the player made the hit
           if(is_Player)
            {
                // Spawn hit effect
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;

                // If facing the right side
                if(hit[0].transform.forward.x > 0)
                {
                    // Show effect in front of enemy
                    hitFX_Pos.x += 0.3f;
                }
                // If facing the left side
                else if (hit[0].transform.forward.x < 0)
                {
                    // Show effect in front of enemy
                    hitFX_Pos.x -= 0.3f;
                }

                // Show hit effect at the position of the enemy
                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);

                // Deal damage
                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG)) {
                    //hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                } else
                {
                    //hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);

                }
            }

           // Deactivate the game object that hit
            gameObject.SetActive(false);
        }
    }
} //class
