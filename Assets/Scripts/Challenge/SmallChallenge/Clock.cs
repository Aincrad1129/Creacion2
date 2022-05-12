using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private ClockChallenge clockChallenge;
    private int _seconds;
    public int seconds { get=> _seconds; }

    [SerializeField] public TMP_Text timeText;

    public bool isComplete = false;
    private void Awake()
    {
        _seconds = Random.Range(0, 86399);
        UpdateText();
        timeText.color = isComplete ? Color.green : Color.black;
    }

    private void Start()
    {
        InvokeRepeating("UpdateTime",0,1);
    }
    public void UpdateTime() {
        if (isComplete) {
            CancelInvoke("UpdateTime");
            return;
        }
        _seconds++;
        if (_seconds > 86399) _seconds = 0;
        UpdateText();
        clockChallenge.CompareClock(this);
    }
    public void SetTime(int amountSeconds)
    {
        if (clockChallenge.isLocked) {
            Debug.Log("Can´t see u change the time");
            return;
        }
        if (!isComplete)
        {
            _seconds += amountSeconds;
            if (_seconds > 86399)
            {
                _seconds = _seconds - 86400;
            }
            UpdateText();
            clockChallenge.CompareClock(this);
        }
    }
    private void UpdateText() => timeText.text = string.Concat((_seconds / 3600).ToString("00"),":", ((_seconds / 60) % 60).ToString("00"),":", (_seconds % 60).ToString("00"));
    


}
