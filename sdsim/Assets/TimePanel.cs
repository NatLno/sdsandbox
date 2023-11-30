using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    [SerializeField]
    Text m_nbLap;

    [SerializeField]
    Text m_timeLap;
    
    [SerializeField]
    Text m_bestTimeLap;

    [SerializeField]
    GameObject m_time;

    [SerializeField]
    GameObject m_parentTime;

    // Start is called before the first frame update
    void Start()
    {
        SetNbLap(1);
    }

    // Update is called once per frame
    void Update()
    {
        Timer timer = GameObject.FindObjectOfType<Timer>();
        if (timer != null)
            m_timeLap.text = timer.currentTotTimeDisp.text;
    }

    public void SetNbLap(int value)
    {
        m_nbLap.text = value.ToString();
    }

    public void SetNextLap(string nbLap)
    {
        GameObject timeObject = Object.Instantiate(m_time, m_parentTime.transform);
        m_timeLap = timeObject.GetComponentsInChildren<Text>()[1];
        timeObject.GetComponentsInChildren<Text>()[0].text = "Lap n°" + nbLap + ":";
    }

    public int TimeStrToSeconde(string strTime)
    {
        string[] tabStr = strTime.Split('\'');
        string[] tabStr2 = (tabStr.Length == 1) ? tabStr[0].Split('.') : tabStr[1].Split('.');
        
        int minutes = (tabStr.Length == 1) ? 0 : int.Parse(tabStr[0]);
        int secondes = int.Parse(tabStr2[0]);
        int millisecondes = int.Parse(tabStr2[1]);
        return minutes * 6000 + secondes * 100 + millisecondes;
    }

    public void SetBestLapTime()
    {
        if (m_bestTimeLap.text.Equals("--.--"))
        {
            m_bestTimeLap.text = m_timeLap.text;
            return;
        }
        int lastTime = TimeStrToSeconde(m_bestTimeLap.text);
        int newTime = TimeStrToSeconde(m_timeLap.text);
        if (newTime < lastTime)
            m_bestTimeLap.text = m_timeLap.text;
    }
}
