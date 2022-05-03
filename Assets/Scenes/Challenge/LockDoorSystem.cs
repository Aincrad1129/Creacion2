using System;
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
    [SerializeField] private Image light;

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
        if (indexPassword == password.Length) checkPassword();
    }

    private void checkPassword()
    {
        print(" ");
        print(currentPassword);
        print(password);

        if (currentPassword == password)
        {
            light.color = Color.green;
            StartCoroutine(CompletePassword(false));
            door.SetActive(false);
        }
        else
        {
            light.color = Color.red;
            StartCoroutine(CompletePassword(true));
            passwordText.text = " ";
            currentPassword = "";
            indexPassword = 0;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")) KeypadUI.SetActive(true);
    }
    private IEnumerator CompletePassword(bool active) {
        yield return new WaitForSeconds(2);
        KeypadUI.SetActive(active);
        light.color = Color.gray;
    }
}
