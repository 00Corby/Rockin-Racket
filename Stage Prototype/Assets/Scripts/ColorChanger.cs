using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour  
{


    Material m_Material;
    MeshRenderer my_renderer = GetComponent<MeshRenderer>();


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guitar")
        {

            Debug.Log("Changing Color Now!");
            

        }

        if (other.gameObject.tag == "Bass")
        {

            Debug.Log("Changing Color Now 2!");

        }

        if (other.gameObject.tag == "Drummer")
        {

            Debug.Log("Changing Color Now 3!");

        }

        if (other.gameObject.tag == "Vocal")
        {

            Debug.Log("Changing Color Now! 4");

        }
    }
}
