using UnityEngine;
using UnityEngine.SceneManagement;

public partial class Portal : MonoBehaviour
{
    public string nomeDaCena;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("fase 1");          
        }
    }
}