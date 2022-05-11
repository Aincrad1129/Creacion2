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
    // Start is called before the first frame update
    void Start()
    {
        passwordText.text = lockDoorSystem.password;
        passwordText.gameObject.SetActive(false);
        print(lockDoorSystem.password);
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
        gameManager.checkChallenges();
    }

    public bool getCompleted() => isComplete;

    public void Restart()
    {
        throw new System.NotImplementedException();
    }

    public async void SetLigth() {
        passwordText.gameObject.SetActive(true);
        fieldOfViewDetec.ForEach(x => x.SwitchOn_OFFCamera(false));
        await Task.Delay(TimeSpan.FromSeconds(timeLightsOff));
        fieldOfViewDetec.ForEach(x => x.SwitchOn_OFFCamera(true));
        passwordText.gameObject.SetActive(false);

    }

    public bool AnyCameraViewPLayer() {
        for (int i = 0; i < fieldOfViewDetec.Count; i++) {
            if (fieldOfViewDetec[i].isviewingPlayer) return true;
        }
        return false;
    }
}
