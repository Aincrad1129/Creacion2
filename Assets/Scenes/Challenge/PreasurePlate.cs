using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    private GameManager gameManager => FindObjectOfType<GameManager>(); 
    [SerializeField] private GameObject target;
    [SerializeField] private int minPlayersAmount;
    [SerializeField] private GameObject platformObject;
    private int playersAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.CompareTag("Player")) {
    //        if (playersAmount < gameManager.players.Count) { 
    //            playersAmount++;
    //        }
    //        if (playersAmount >= minPlayersAmount) target.GetComponent<IAction>().OnEnterAction();
    //        if (playersAmount <= minPlayersAmount) platformObject.transform.position += Vector3.down * 0.05f;
            
    //    }
        
    //}

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {   
            if (playersAmount > 0)
            {
                playersAmount --;
            }
            if (playersAmount < minPlayersAmount)
            { 
                target.GetComponent<IAction>().OnExitAction();
             platformObject.transform.position += Vector3.up * 0.05f;

            }

        }
    }

    
}
