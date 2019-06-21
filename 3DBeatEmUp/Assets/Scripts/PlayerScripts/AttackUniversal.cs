using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX;


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
            print("We hit this " + hit[0].gameObject.name);

            gameObject.SetActive(false);
        }
    }
} //class
