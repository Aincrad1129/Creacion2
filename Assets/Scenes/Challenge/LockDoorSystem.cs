using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockDoorSystem : MonoBehaviour
{
    public string password;
    private int paswordLength;
    private string currentPassword = "";
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject KeypadUI;
    [SerializeField] private Text passwordText;
    [SerializeField] private Image lightSignal;

    private int indexPassword = 0;

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
        currentPassword = $"{currentPassword}{number}";
        passwordText.text = $"{passwordText.text}* ";
        print(currentPassword);
        indexPassword++;
        if (indexPassword == password.Length) CheckPassword();
    }

    private void CheckPassword()
    {
        if (currentPassword == password)
        {
            lightSignal.color = Color.green;
            CompletePassword(false);
            door.SetActive(false);
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
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")) KeypadUI.SetActive(true);
    }

    private async void CompletePassword(bool active) {
        await Task.Delay(TimeSpan.FromSeconds(2));
        KeypadUI.SetActive(active);
        lightSignal.color = Color.gray;
    }
}
