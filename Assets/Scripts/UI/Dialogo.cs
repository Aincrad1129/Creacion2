using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject Mark; // indicador visual si aparaece se pueden activar los textos
    [SerializeField] private GameObject PanelDialogo; // recuadro donde esta el dialogo
    [SerializeField] private TMP_Text TextDialogo; // el texto que se muestra uno a uno
    [SerializeField, TextArea(2,4)] private string[] lineasDialogo; // recuadros donde sale cada linea de texto
    private bool isPLayerinRange; // el trigger que activa la posibilidad de mostrar texto
    private bool iniciaDialogo; // activa el dialogo
    private int lineaDialogo01; //  linea que muestra
    private float tiempoEscritura = 0.05f; 

                    
    // Update is called once per frame
    void Update()
    {
        if (isPLayerinRange && Input.GetButtonDown("Fire1")) // cambiar a "mando" se hace con click para testear
        {
            if (!iniciaDialogo)
            {
                StartDialogo();
            }
            else if (TextDialogo.text == lineasDialogo[lineaDialogo01])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                TextDialogo.text =  lineasDialogo[lineaDialogo01];  
            }
        }
        
    }
     private void StartDialogo() //activa dialogo
    {
        iniciaDialogo = true;
        PanelDialogo.SetActive(true);
        Mark.SetActive(false);
        lineaDialogo01 = 0;
        Time.timeScale = 0f;
        StartCoroutine(MostrarLinea());
    }

    private void SiguienteLinea() // corta linea una a una para mostrar
    {
     lineaDialogo01++; 
     if (lineaDialogo01 < lineasDialogo.Length)
        {
         StartCoroutine(MostrarLinea());    
        }
        else
        {
            iniciaDialogo = (false);
            PanelDialogo.SetActive(false);
            Mark.SetActive(true);
            Time.timeScale = 1;
        }

    }

    private IEnumerator MostrarLinea() // muestra en pantalla cada linea
    {
        TextDialogo.text = string.Empty;
        foreach (char ch in lineasDialogo[lineaDialogo01])
        {
            TextDialogo.text += ch;
            yield return new WaitForSecondsRealtime(tiempoEscritura);
        }

    }


    private void OnTriggerEnter(Collider other) // trigger que activa los objetos del canvas
    {
        if (other.CompareTag("Player"))
        {
            isPLayerinRange = true;
            Mark.SetActive(true);
            Debug.Log("inicia dialogo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPLayerinRange = false;
            Mark.SetActive(false);
            Debug.Log("no puede inicia dialogo");
        }
    }
   
}
