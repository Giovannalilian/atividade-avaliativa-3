using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dano : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);          
        }
    }
}
