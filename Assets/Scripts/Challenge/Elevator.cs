using UnityEngine;

public class Elevator : MonoBehaviour, IAction
{
    private Vector3 startPositon;
    [SerializeField] private Vector3 endPositon;
    public bool active;
    [SerializeField]private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        startPositon = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (this.transform.position != endPositon) this.transform.position = Vector3.MoveTowards(this.transform.position, endPositon, velocity * Time.deltaTime);
        }
        else
        {
            if (this.transform.position != startPositon) this.transform.position = Vector3.MoveTowards(this.transform.position, startPositon, velocity * Time.deltaTime);
        }

    }
    public void OnEnterAction() {
        active = true;
    }
    public void OnExitAction()
    {
        active = false;
    }

}
