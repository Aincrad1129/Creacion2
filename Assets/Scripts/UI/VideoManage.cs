using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManage : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject BG;
    [SerializeField] GameObject avisoPanel;
    [SerializeField] float Delay = 5f;
    [SerializeField] float menuDelay = 8f;
    [SerializeField] float avisoDelay = 8f;
    // Start is called before the first frame update
    void Start()
    {
        BG.SetActive(true);
        Invoke("VideoDelay", Delay);
    }

    public void VideoDelay()
    {
        BG.SetActive(false);
        videoPlayer.Play();
        Invoke("Aviso", avisoDelay);
    }
    public void MenuDelay()
    {
        SceneManager.LoadScene(1);
    }

    public void Aviso()
    {
        BG.SetActive(true);
        avisoPanel.SetActive(true);
        videoPlayer.Stop();
        Invoke("MenuDelay", menuDelay);
    }
}
