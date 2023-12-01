using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLap : MonoBehaviour
{
    [SerializeField]
    int m_nbLap = 0;

    [SerializeField]
    bool m_beginLap;

    [SerializeField]
    GameObject m_portalCheckpoint;
    
    [SerializeField]
    CheckLap m_nextCheckPoint;

    [SerializeField]
    List<CheckLap> m_checkPoints;

    [SerializeField]
    TimePanel m_timePanel;

    bool m_trigger = false;

    private void Start()
    {
        foreach (CheckLap checkPoint in m_checkPoints)
        {
            checkPoint.m_portalCheckpoint.SetActive(false);
        }
        if (m_checkPoints.Count > 0)
            m_checkPoints[0].m_portalCheckpoint.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (!m_beginLap)
            {
                if (m_portalCheckpoint.activeInHierarchy && !m_trigger) { 
                    m_trigger = true;
                    m_portalCheckpoint.SetActive(false);
                    m_nextCheckPoint.m_portalCheckpoint.SetActive(true);
                }
            }

            if (m_beginLap && CheckAllCheckpoint())
            {
                m_nbLap++;
                if (m_timePanel != null)
                {
                    m_timePanel.SetNbLap(m_nbLap);
                    SetLapTime();
                }
                ResetCheckPoints();
            }
            
            Timer timer = GameObject.FindObjectOfType<Timer>();
            if (m_beginLap && timer && !timer.enabled_timer)
            {
                timer.StartTimer();
            }
        }
    }

    private bool CheckAllCheckpoint()
    {
        foreach (CheckLap checkPoint in m_checkPoints)
        {
            if (!checkPoint.m_trigger)
                return false;
        }
        return true;
    }

    private void ResetCheckPoints()
    {
        foreach (CheckLap checkPoint in m_checkPoints)
        {
            checkPoint.m_trigger = false;
        }
    }

    void SetLapTime()
    {
        Timer timer = GameObject.FindObjectOfType<Timer>();
        if (timer)
        {
            m_timePanel.SetBestLapTime();
            m_timePanel.SetNextLap(m_nbLap.ToString());
            timer.DisableTimer();
            timer.StartTimer();
        }
    }
}
