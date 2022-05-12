using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class LightsChallenge : MonoBehaviour, IChallenge
{
    private bool isComplete;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LockDoorSystem lockDoorSystem;
    [SerializeField] private List<FieldOfViewDetec> fieldOfViewDetec = new List<FieldOfViewDetec>();
    [SerializeField] public TMP_Text passwordText;
    [SerializeField] private int timeLightsOff;

    [SerializeField] private GameObject completeIndicator;
    [SerializeField] private Material activeMaterial;
    private bool isLightOn;

    [SerializeField] private string OffSound;
    [SerializeField] private string OnSound;
    [SerializeField] private string AbrirPuerta;
    private AudioManager audioManager;
    [SerializeField] private Animator abrirL, abrirR;

    // Start is called before the first frame update

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        passwordText.text = lockDoorSystem.password;
        passwordText.gameObject.SetActive(false);
        abrirL.GetComponent<Animator>();
        abrirL.enabled = false;
        abrirR.GetComponent<Animator>();
        abrirR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Complete()
    {
        Debug.Log("Complete:" + GetType().Name);
        isComplete = true;
        completeIndicator.GetComponent<MeshRenderer>().material = activeMaterial;
        abrirL.enabled = true;
        abrirR.enabled = true;
        gameManager.checkChallenges();
    }

    public bool getCompleted() => isComplete;

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    public async void SetLigth() {
        audioManager.PlaySound(OffSound);
        passwordText.gameObject.SetActive(true);
        fieldOfViewDetec.ForEach(x => x.SwitchOn_OFFCamera(false));
        await Task.Delay(TimeSpan.FromSeconds(timeLightsOff));
        fieldOfViewDetec.ForEach(x => x.SwitchOn_OFFCamera(true));
        passwordText.gameObject.SetActive(false);
        audioManager.PlaySound(OnSound);
    }

    public bool AnyCameraViewPLayer() {
        for (int i = 0; i < fieldOfViewDetec.Count; i++) {
            if (fieldOfViewDetec[i].isviewingPlayer) return true;
        }
        return false;
    }
}
