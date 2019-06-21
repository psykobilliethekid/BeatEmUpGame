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
                // Get the position of the enemy and spawn hit effect
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;

                // If facing the right side
                if(hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }
                // If facing the left side
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);
            }

           // Deactivate the game object that hit
            gameObject.SetActive(false);
        }
    }
} //class
