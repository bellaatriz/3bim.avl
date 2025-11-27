using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField] private int dano = 1;

    public float raioDeVisao = 1;
    public CircleCollider2D _visaoCollider2D;

    [SerializeField] private Transform posicaoPlayer;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool andando = false;
    
    public AudioSource audioSource;

    public void setDano(int dano)
    {
        this.dano = dano;
    }
    public int getDano()
    {
        return this.dano;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (posicaoPlayer == null)
        {
            posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }

        raioDeVisao = _visaoCollider2D.radius;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        andando = false;

        if (getVidas() > 0)
        {
            if (posicaoPlayer.position.x - transform.position.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            if (posicaoPlayer.position.x - transform.position.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            if (posicaoPlayer != null &&
                Vector3.Distance(posicaoPlayer.position, transform.position) <= raioDeVisao)
            {
                Debug.Log("No raio de vis�o" + posicaoPlayer.position);

                transform.position = Vector3.MoveTowards(transform.position,
                    posicaoPlayer.transform.position,
                    getVelocidade() * Time.deltaTime);

                andando = true;
            }
        }

        if (getVidas() <= 0)
        {
            animator.SetTrigger("Morte");
        }

        animator.SetBool("Andando", andando);
    }

    public void desative()
    {
        Destroy(gameObject);
        Debug.Log("Teste...");
    }
    
    public void playSound()
    {
        audioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && getVidas() > 0)
        {
            Personagem player = collision.gameObject.GetComponent<Personagem>();

            if (player != null)
            {
                int novaVida = player.getVidas() - getDano();
                player.setVidas(novaVida);
            }
        }
    }
}