using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaDesvanecerse : MonoBehaviour
{
    public AudioSource sonidoFantasma; // El sonido del violín o risa del niño
    public SpriteRenderer spriteFantasma; // El SpriteRenderer del fantasma
    public float tiempoDesvanecerse = 3f; // Tiempo que tarda en desvanecerse

    private bool desvaneciendo = false;
    private float contador = 0f;

    void Start()
    {
        sonidoFantasma.Play(); // Reproducir el sonido del fantasma al iniciar la escena
        desvaneciendo = true;  // Inicia el desvanecimiento del fantasma
    }

    void Update()
    {
        if (desvaneciendo)
        {
            contador += Time.deltaTime; // Incrementa el contador

            float nuevoAlpha = 1f - (contador / tiempoDesvanecerse); // Calcula el nuevo alpha (opacidad)

            // Cambia la opacidad del sprite
            spriteFantasma.color = new Color(1f, 1f, 1f, nuevoAlpha);

            // Si ha pasado el tiempo, desactiva el fantasma
            if (contador >= tiempoDesvanecerse)
            {
                spriteFantasma.gameObject.SetActive(false); // Desactiva el GameObject del fantasma
                desvaneciendo = false; // Detiene el desvanecimiento
            }
        }
    }
}
