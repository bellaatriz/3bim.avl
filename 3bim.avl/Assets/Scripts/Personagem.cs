using UnityEngine;

public class Personagem : MonoBehaviour
{
    [SerializeField] private int vidas;
    [SerializeField] private int energia;
    [SerializeField] private float velocidade;

    public void setVidas(int vidas)
    {
        this.vidas = vidas;
    }

    public int getVidas()
    {
        return vidas;
    }

    public void setEnergia(int energia)
    {
        this.energia = energia;
    }

    public int getEnergia()
    {
        return energia;
    }

    public void setVelocidade(float velocidade)
    {
        this.velocidade = velocidade;
    }

    public float getVelocidade()
    {
        return this.velocidade;
    }
        
      
}
