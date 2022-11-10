using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public int currentHealth = 5;

    public int damageAmount = 1;

    public Material[] material;
    Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 4)
            {
                rend.sharedMaterial = material[1];
            }

            if (currentHealth <= 3)
            {
                rend.sharedMaterial = material[2];
            }

            if (currentHealth <= 2)
            {
                rend.sharedMaterial = material[3];
            }

            if (currentHealth <= 1)
            {
                rend.sharedMaterial = material[4];
            }

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
