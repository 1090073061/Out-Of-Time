using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    public float maxHealth;
    float currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float damageAmount)
    {
        if(damageAmount > currHealth)
        {
            currHealth = 0;
        }
        else
        {
            currHealth -= damageAmount;
        }
        
    }

    void Heal(float healAmount)
    {
        if(currHealth + healAmount > maxHealth)
        {
            currHealth = maxHealth;
        }
        else
        {
            currHealth += healAmount;
        }
    }
}
