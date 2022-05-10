using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonSwitchs = new List<GameObject>();
    private bool _state;
    public bool state { get => _state; }
    private Material mat;

    [HideInInspector] public bool isChanging;
    [SerializeField] private SwitchChallenge switchChallenge;
    // Start is called before the first frame update
    private void Awake()
    {
        _state = (int)Random.Range(0, 5) % 2 == 0;
        mat = switchChallenge.GetMaterial(_state);
        this.GetComponent<MeshRenderer>().material = mat;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setState(GameObject button)
    {
        if (buttonSwitchs.Find(x => x == button)) _state = !_state;
        isChanging = false;
        mat = switchChallenge.GetMaterial(_state);
        this.GetComponent<MeshRenderer>().material = mat;
        switchChallenge.Check();
    }
    public void randomState()
    {
        _state = (int)Random.Range(0, 5) % 2 == 0;
        mat = switchChallenge.GetMaterial(_state);
        this.GetComponent<MeshRenderer>().material = mat;
        switchChallenge.CheckRandomState();
    }

}
