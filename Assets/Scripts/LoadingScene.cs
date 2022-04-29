using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public string sceneName;
    private float timer = 0f;
    public const float limiteTiempo = 5f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= limiteTiempo)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
    
    
        
        
        

}