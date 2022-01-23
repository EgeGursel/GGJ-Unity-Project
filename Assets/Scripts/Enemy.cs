using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem blood;
    public int maxHP;
    int currHP;
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }
    public void TakeDamage (int damage)
    {
        currHP -= damage;
        // ADD HURT ANIMATION

        if (currHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        blood.Play();
        Destroy(gameObject);
    }
    
}
