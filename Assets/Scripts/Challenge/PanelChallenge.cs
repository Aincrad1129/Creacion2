using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChallenge : MonoBehaviour,IChallenge
{

    private bool isComplete;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FieldOfViewDetec fieldOfViewDetec;
    [SerializeField] private GameObject completeIndicator;
    [SerializeField] private Material activeMaterial;
    public void Complete()
    {
        if (!fieldOfViewDetec.isviewingPlayer)
        {
            Debug.Log("Complete:" + GetType().Name);
            isComplete = true;
            completeIndicator.GetComponent<MeshRenderer>().material = activeMaterial;
            gameManager.checkChallenges();
        }
        else {
            Debug.Log("Can´t see u to unlock the panel");
        }
    }

    public bool getCompleted() => isComplete;

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    
}
