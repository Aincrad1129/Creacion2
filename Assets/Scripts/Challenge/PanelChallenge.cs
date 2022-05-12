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
    [SerializeField] private Animator abrirL, abrirR;
    [SerializeField] private string AbrirPuerta;
    private AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        abrirL.GetComponent<Animator>();
        abrirL.enabled = false;
        abrirR.GetComponent<Animator>();
        abrirR.enabled = false;

    }
    public void Complete()
    {
        if (!fieldOfViewDetec.isviewingPlayer)
        {
            Debug.Log("Complete:" + GetType().Name);
            isComplete = true;
            completeIndicator.GetComponent<MeshRenderer>().material = activeMaterial;
            audioManager.PlaySound(AbrirPuerta);
            abrirL.enabled = true;
            abrirR.enabled = true;
            gameManager.checkChallenges();
        }
        else {
            Debug.Log("Can´t see u to unlock the panel");
            abrirL.enabled = false;
            abrirR.enabled = false;
        }
    }

    public bool getCompleted() => isComplete;

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    
}
