using UnityEngine;
using UnityEngine.SceneManagement;

public class Dano : MonoBehaviour
{
    public float tempoAnimacaoMorte = 0.3f; // tempo da animação em segundos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pega o Animator do player
            Animator animator = other.GetComponent<Animator>();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            MonoBehaviour playerScript = other.GetComponent<MonoBehaviour>(); // seu script de controle do player

            if (animator != null)
            {
                animator.SetBool("Dano", true); // toca a animação de morte
            }

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; // para o player
                rb.bodyType = RigidbodyType2D.Static; // opcional: trava totalmente
            }

            if (playerScript != null)
            {
                playerScript.enabled = false; // desativa o controle do player
            }

            // reinicia a cena após o tempo da animação
            Invoke("ReiniciarCena", tempoAnimacaoMorte);
        }
    }

    private void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}