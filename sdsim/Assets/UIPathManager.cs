using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathManager : MonoBehaviour
{
    [SerializeField]
    PathManager pathManager;

    [SerializeField]
    PathCreator leftSidePath;
    [SerializeField]
    PathCreator middlePath;
    [SerializeField]
    PathCreator rightSidePath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeftSidePath()
    {
        pathManager.pathCreator = leftSidePath;
        foreach (Transform child in pathManager.transform)
        {
            Destroy(child.gameObject);
        }
        pathManager.InitCarPath();
    }

    public void SetMiddlePath()
    {
        pathManager.pathCreator = middlePath;
        foreach (Transform child in pathManager.transform)
        {
            Destroy(child.gameObject);
        }
        pathManager.InitCarPath();
    }

    public void SetRightSidePath()
    {
        pathManager.pathCreator = rightSidePath;
        foreach (Transform child in pathManager.transform)
        {
            Destroy(child.gameObject);
        }
        pathManager.InitCarPath();
    }
}
