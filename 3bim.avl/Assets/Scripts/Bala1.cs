using UnityEngine;

public class Bala1 : MonoBehaviour
{

    [SerializeField] private int dano = 1;
    [SerializeField] private float velocidade = 1.5f;
    
    private Renderer m_renderer;


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
        m_renderer = GetComponent<Renderer>();    
    }

   
    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0, 0);

        if (!m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
        
        
    }




    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.CompareTag("Inimigo"))
        {
            int novaVida = colisao.gameObject.GetComponent<Personagem>().getVida()- getDano();
            colisao.gameObject.GetComponent<Personagem>().setVida(novaVida);
            
            Destroy(this.gameObject);
        }
        
        
        
    }
    
    
    
    
    
}