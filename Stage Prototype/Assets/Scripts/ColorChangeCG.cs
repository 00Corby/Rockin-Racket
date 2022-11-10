using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeCG : MonoBehaviour
{
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
        if (other.gameObject.tag == "Guitar")
        {

            Debug.Log("Changing Color Now!");
            rend.sharedMaterial = material[1];


        }

        if (other.gameObject.tag == "Bass")
        {

            Debug.Log("Changing Color Now 2!");
            rend.sharedMaterial = material[3];

        }

        if (other.gameObject.tag == "Drummer")
        {

            Debug.Log("Changing Color Now 3!");
            rend.sharedMaterial = material[2];

        }

        if (other.gameObject.tag == "Vocal")
        {

            Debug.Log("Changing Color Now! 4");
            rend.sharedMaterial = material[4];

        }
    }
}
