using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DesaparecerPlatf : MonoBehaviour
{
    private bool firstTouch = false;
    [SerializeField]private int seconds;

    // Start is called before the first frame update 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Vector3 hit = col.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 180) && !firstTouch)
            {
                firstTouch = true;
                Debug.Log("Down");
                DesaparecerPlat();
            }
        }

    }
    public async void DesaparecerPlat()
    {
        await Task.Delay(seconds * 1000);
        this.gameObject.SetActive(false);
    }
}
