using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    private int count;

    public Text countText;

    // Start is called before the first frame update
    void Awake()
    {
        SetScoreCount();
        count = 0;
    }

    void SetScoreCount()
    {
        countText.text = "Fan Points: " + count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
         
            count += 150;

            SetScoreCount();
        }

    }
}