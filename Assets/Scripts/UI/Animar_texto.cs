using System.Collections;
using UnityEngine;
using TMPro;
public class Animar_texto : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI frase;
    [SerializeField, TextArea(4, 4)] string oracion;
    private int largoOracion;
    private int indexOracion;

    [Header("Configuration")]
    [SerializeField] float PausaDelay = 2.0f;
    [SerializeField] float RetrasoDelay = 0.1f;
    [SerializeField] private bool limpiarCreditosAlSalir;

    void Start()
    {
        largoOracion = oracion.Length;
        indexOracion = 0;
        //StartCoroutine(Pausa());
    }
    IEnumerator Pausa()
    {
        yield return new WaitForSeconds(PausaDelay);
        StartCoroutine(Retraso());
    }

    public void Puente()
    {
        StartCoroutine(Retraso());
    }
    IEnumerator Retraso()
    {
        foreach (char letra in oracion)
        {
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(RetrasoDelay);
        }
    }

    public void ComenzarAEscribir() {
        InvokeRepeating("Escribir", PausaDelay,RetrasoDelay);
    }

    private void Escribir() {
        print("letra");
        frase.text += oracion.Substring(indexOracion,1);
        indexOracion++;
        if (indexOracion >= largoOracion-1)  CancelInvoke("Escribir");
}
    public void PararDeEscribir() {
        CancelInvoke("Escribir");
        if(limpiarCreditosAlSalir) indexOracion = 0;
    }   
 }
