using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LockDoorSystem : MonoBehaviour, IChallenge
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LightsChallenge lightsChallenge;
    private bool isComplete;
    [HideInInspector] public string password;
    private int paswordLength;
    private string currentPassword = "";
    [SerializeField] private GameObject KeypadUI;
    [SerializeField] private Text passwordText;
    [SerializeField] private Image lightSignal;

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject StartButtonUI;
    private bool CanPress = false;



    private int indexPassword = 0;
    private void Awake()
    {
        int randompasword = UnityEngine.Random.Range(0, 9999);
        password = randompasword.ToString("0000");
        lightsChallenge.passwordText.text = password;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        paswordLength = password.Length;
        KeypadUI.SetActive(false);
        passwordText.text = " ";
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getNumber(string number)
    {
        if (!CanPress)
            return;

        currentPassword = $"{currentPassword}{number}";
        passwordText.text = $"{passwordText.text}* ";
        indexPassword++;
        if (indexPassword == password.Length) CheckPassword();
    }

    private void CheckPassword()
    {
        CanPress = false;

        if (currentPassword == password)
        {
            lightSignal.color = Color.green;
            CompletePassword(false);
            lightsChallenge.Complete();
            //door.SetActive(false);
        }
        else
        {
            lightSignal.color = Color.red;
            CompletePassword(true);
            passwordText.text = " ";
            currentPassword = "";
            indexPassword = 0;
        }
    }
    public void OpenKeyPadUI()
    {
        KeypadUI.SetActive(true);
        eventSystem.SetSelectedGameObject(StartButtonUI);
        gameManager.setPause(true);
        CanPress = true;
    }

    private async void CompletePassword(bool active) {
        await Task.Delay(TimeSpan.FromSeconds(0.75f));
        KeypadUI.SetActive(false);
        lightSignal.color = Color.gray;
        gameManager.setPause(false);

    }

    public void Complete()
    {
        throw new NotImplementedException();
    }

    public void Restart()
    {
        throw new NotImplementedException();
    }

    public bool getCompleted() => isComplete;
}
