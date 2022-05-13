using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Animar_texto : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI frase;
    [SerializeField, TextArea(4, 4)] string oracion;

    [Header("Configuration")]
    [SerializeField] float PausaDelay = 2.0f;
    [SerializeField] float RetrasoDelay = 0.1f;

    void Start()
    {
        StartCoroutine(Pausa());
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
        Debug.Log("Retraso");
        Debug.Log(oracion);
        foreach (char letra in oracion)
        {
            Debug.Log("Si");
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(RetrasoDelay);
        }
    }
}
