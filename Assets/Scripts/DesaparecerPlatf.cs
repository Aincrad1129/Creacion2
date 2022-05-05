using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DesaparecePlatf : MonoBehaviour
{
    public GameObject plataforma;
    private bool firstTouch = false;
    public int seconds;

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
        if (col.gameObject.tag.Equals("Platform"))
        {
            Vector3 hit = col.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 0) && !firstTouch)
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
        Destroy(plataforma);
    }
}
