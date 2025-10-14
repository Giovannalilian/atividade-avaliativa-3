using System;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}