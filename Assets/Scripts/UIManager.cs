using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private float _timeToCountdown = 7f;
    private float _countdownTimeFromRealityStone;

    private bool _isTimerGoing = false;

    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Image _textBackground;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(_isTimerGoing)
        {
            if (_timeToCountdown > 0)
            {
                _timeToCountdown -= Time.deltaTime;
                CountdownTimer(_timeToCountdown);
            }
            else
            {
                _timeToCountdown = 0;
                _isTimerGoing = false;
                _timerText.text = _timeToCountdown + ":000";
            }
        }
    }

    public void StoneActivation(bool StoneStatus)
    {
        StartCoroutine(FadingAlpha(StoneStatus));
    }
    
    IEnumerator FadingAlpha(bool isActivated)
    {
        if(isActivated)
        {
            for(float i = 0; i <= 1; i += Time.deltaTime)
            {
                _textBackground.color = new Color(1, 1, 1, i);
                _timerText.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for(float i = 1; i >= 0; i -= Time.deltaTime)
            {
                _textBackground.color = new Color(1, 1, 1, i);
                _timerText.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    public void StartCountdown(float timesFromStone)
    {
        _countdownTimeFromRealityStone = timesFromStone;
        _timeToCountdown = _countdownTimeFromRealityStone;
        _isTimerGoing = true;
    }

    void CountdownTimer(float timeLeft)
    {
        //timeLeft += 1;

        float seconds = Mathf.FloorToInt(timeLeft % 60);
        float milliSeconds = (timeLeft % 1) * 1000;

        _timerText.text = string.Format("{0:0}:{1:000}", seconds, milliSeconds);
    }
}
