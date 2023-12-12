using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConesManager : MonoBehaviour
{
    [SerializeField]
    Transform m_coneParent;

    [SerializeField]
    List<Transform> m_cones;

    public List<Transform> Cones
    {
        get => m_cones;
    }

    private void Start()
    {
        foreach (Transform child in m_coneParent)
        {
            if (child.gameObject.activeInHierarchy)
                m_cones.Add(child);
        }
    }

}
