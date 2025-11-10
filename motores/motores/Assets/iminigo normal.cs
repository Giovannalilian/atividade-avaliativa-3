using UnityEngine;

public class Inimigo : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    
    private GameObject player;

    public float distanciaDeVisao = 10;
    public float velocidade = 5;
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
       // player = GameObject.Find("Player");
       player = GameObject.FindGameObjectWithTag("Player");
    }

   
    void Update()
    {
        if (player != null)
        {
            //posição do player
            Debug.Log(player.transform.position);

            //direita
            if (player.transform.position.x > transform.position.x
                && Mathf.Abs(player.transform.position.x - transform.position.x) < distanciaDeVisao)
            {
                transform.position += Vector3.right * velocidade * Time.deltaTime;
                spriteRenderer.flipX = true;
            }
            
            //esquerda
            if (player.transform.position.x < transform.position.x
                && Mathf.Abs(player.transform.position.x - transform.position.x) < distanciaDeVisao)
            {
                transform.position -= Vector3.right * velocidade * Time.deltaTime;
                spriteRenderer.flipX = false;
            }

        }

    }
}
