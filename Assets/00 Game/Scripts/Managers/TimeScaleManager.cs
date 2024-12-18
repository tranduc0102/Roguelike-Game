using TMPro;
using UnityEngine;

public class TimeScaleManager : Singleton<TimeScaleManager>
{
    [SerializeField] protected float curTimeScale;
    public TextMeshProUGUI txtTime;

    private int time;
    public int idWave = 0;
    public int TimeX
    {
        get { return time; }
        set
        {
            time = value;
            txtTime.text = $"Time wave {idWave}: {time}";
        }
    }
    private float second = 1f;
    private float cnt = 0;
    public virtual void SetNewSpeedGame(float newSpeed)
    {
        curTimeScale = Time.timeScale;
        Time.timeScale = newSpeed;
    }

    public virtual void ResetToInitialSpeed()
    {
        Time.timeScale = curTimeScale;
    }

    public virtual void StopGame()
    {
        SetNewSpeedGame(0);
    }

    private void Update()
    {
        cnt += Time.deltaTime;
        if (cnt > second)
        {
            TimeX -= 1;
            cnt = 0;
        }
    }
}
