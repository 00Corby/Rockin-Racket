using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public int currentHealth = 5;

    public int damageAmount = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
