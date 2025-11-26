using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ControleDeAudio : MonoBehaviour
{
    public int volume;
    public int volumeSFX;
    public bool musica;
    
    public Slider volumeSlider;
    public Slider volumeSFXSlider; 
    public Toggle toggleMusica;
    public TMP_Text textoMusica;
    
    void Start()
    {
        musica = toggleMusica.isOn;
        volume = (int)volumeSlider.value;
        volumeSFX = (int)volumeSFXSlider.value;
    }
    
    void Update()
    {
        musica = toggleMusica.isOn;
        volume = (int)volumeSlider.value;
        volumeSFX = (int)volumeSFXSlider.value;

        if (musica == true)
        {
            textoMusica.text = "Ligado";
            textoMusica.color = Color.green;
        }
        else
        {
            textoMusica.text = "Desligado";
            textoMusica.color = Color.red;
        }
        
    }
}
