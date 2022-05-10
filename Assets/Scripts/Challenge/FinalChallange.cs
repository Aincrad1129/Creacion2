using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class FinalChallange : MonoBehaviour, IChallenge
{
    private bool isComplete;
    public GameObject door;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CineMachineSwitch cineMachineSwitch;
    [SerializeField] private List<GameObject> completeChallengeButton = new List<GameObject>();
    [SerializeField] private Material activeMat;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject plataformsParent;
    [SerializeField] private int timeToStartMovePlatform;
    [SerializeField] private ObjectCollider finalCollider;
    private List<DesaparecerPlatf> platforms = new List<DesaparecerPlatf>();
    private Vector3 startPositionLaser;
    [HideInInspector]public bool isUnlocked;
    private bool moveLaser = false;

    private KillPlayer killPlayer;

    void Awake() {
        finalCollider.CollideWithPlayerEnter += () => Complete();
    }
    // Start is called before the first frame update
    void Start()
    {
        killPlayer = FindObjectOfType<KillPlayer>();
        startPositionLaser = laser.transform.position;
        platforms.AddRange(plataformsParent.GetComponentsInChildren<DesaparecerPlatf>());
        moveLaser = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLaser) {
            laser.transform.position += (Vector3.up * 0.5f) * Time.deltaTime;
        }
        if (killPlayer.playerDead)
        {
            laser.transform.position = startPositionLaser;
            moveLaser = false;
        }
        
    }

    public void Complete()
    {
        Debug.Log("Complete:" + GetType().Name);
        isComplete = true;
        moveLaser = false;
    }

    public bool getCompleted()
    {
        throw new System.NotImplementedException();
    }


    public async void Restart()
    {
        killPlayer.Kill();
        moveLaser = false;
        await Task.Delay(TimeSpan.FromSeconds(killPlayer.playerTimeRestart / 2));
        laser.transform.position = startPositionLaser;

        platforms.ForEach(x => x.gameObject.SetActive(true));
    }

    public void SetButton(int index) {
        completeChallengeButton[index].GetComponent<MeshRenderer>().material = activeMat;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (isUnlocked) {
                cineMachineSwitch.animator.SetBool("WorldCamera", true);
                gameManager.finalChallengeUnloke = true;
                killPlayer.SetRespawnPoitn(respawnPoint);
                StartMovPlatform();    
            }
        }
    }

    public async void StartMovPlatform()
    {
        await Task.Delay(TimeSpan.FromSeconds(timeToStartMovePlatform));
        moveLaser = true;
        /*
        while (!killPlayer.playerDead || !isComplete)
        {
            laser.transform.position += Vector3.up;
        }*/
    }




}
