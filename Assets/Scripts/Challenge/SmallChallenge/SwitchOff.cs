using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class SwitchOff : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    [SerializeField] private List<GameObject> lights = new List<GameObject>();
    [SerializeField] private List<GameObject> panels = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOff() {
        cameras.ForEach(x => x.GetComponent<FieldOfViewDetec>().SwitchOn_OFFCamera(false));
        TurnOn();
    }

    public async void TurnOn() {

        await Task.Delay(TimeSpan.FromSeconds(time));
        cameras.ForEach(x => x.GetComponent<FieldOfViewDetec>().SwitchOn_OFFCamera(true));   
    }
}
