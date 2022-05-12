using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Consejos : MonoBehaviour
{
    [SerializeField] [TextArea(2, 4)] private List<string> consejos = new List<string>();
    [SerializeField] private TMP_Text TextDialogo;
    [SerializeField] private bool changeOverTime;
    [SerializeField] private float timeToChange;
    // Start is called before the first frame update
    void Start()
    {
        SetDialogo();
        if (changeOverTime) InvokeRepeating("SetDialogo", timeToChange, timeToChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDialogo() {
        int index = Random.Range(0,consejos.Count *2 -1);
        print("index"+index );
        print(index % (consejos.Count - 1));
        TextDialogo.text = consejos[index % consejos.Count];
    }
}
