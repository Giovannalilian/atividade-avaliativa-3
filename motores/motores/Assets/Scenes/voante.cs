using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
        
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    
    private GameObject player;

    public float distanciaDeVisao = 3;
    public float velocidade = 2;

    public Transform[] pontosDePatrulha;
    private int pontoAtual = 0;
    
   void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        // player = GameObject.Find("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        
      for(int i = 0; i <pontosDePatrulha.Length; i++)
        {
          //  player.transform.GetChild(i).SetParent(null);
          
          Debug.Log(pontosDePatrulha[i].name);
          
          pontosDePatrulha[i].transform.SetParent(null);
        }
        
    }
  void Update()
    {
        if (player != null)
        {
            //posição do player
           // Debug.Log(player.transform.position);
            
            if(Mathf.Abs(player.transform.position.x - transform.position.x) > distanciaDeVisao ||
               Mathf.Abs(player.transform.position.y - transform.position.y) > distanciaDeVisao)
            {
                Debug.Log(pontoAtual);
                
                transform.position = Vector3.MoveTowards(transform.position, 
                    pontosDePatrulha[pontoAtual].position, 
                    velocidade * Time.deltaTime);

                if(Mathf.Abs(pontosDePatrulha[pontoAtual].position.x - transform.position.x) <= 0.01f ||
                   Mathf.Abs(pontosDePatrulha[pontoAtual].position.y - transform.position.y) <= 0.01f)
                {
                    pontoAtual++;
                    if (pontoAtual >= pontosDePatrulha.Length)
                    {
                        pontoAtual = 0;
                    }

                    if (pontosDePatrulha[pontoAtual].position.x > transform.position.x)
                    {
                        spriteRenderer.flipX = true;
                    }

                    else
                    if (pontosDePatrulha[pontoAtual].position.x < transform.position.x)
                    {
                        spriteRenderer.flipX = false;
                    }
                }
            }
            else
            {
                pontoAtual = 0;
            }
            
            

            //direita
            if (player.transform.position.x > transform.position.x
                && Mathf.Abs(player.transform.position.x - transform.position.x) < distanciaDeVisao)
            {
               transform.position = Vector3.MoveTowards(transform.position, 
                   player.transform.position, 
                   velocidade * Time.deltaTime);
              
               spriteRenderer.flipX = true;
            }
            else
            //esquerda
            if (player.transform.position.x < transform.position.x
                && Mathf.Abs(player.transform.position.x - transform.position.x) < distanciaDeVisao)
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                    player.transform.position, 
                    velocidade * Time.deltaTime);
                
                spriteRenderer.flipX = false;
            }
         
       

        }
    }
}
