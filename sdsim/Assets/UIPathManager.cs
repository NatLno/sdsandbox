using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathManager : MonoBehaviour
{
    [SerializeField]
    PathManager pathManager;

    //[SerializeField]
    //CarSpawner carSpawner;

    //[SerializeField]
    //GameObject car;
    //[SerializeField]
    //GameObject carPidController;

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
        //if (carSpawner.cars.Count >= 0)
        //    car = carSpawner.cars[0];
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

    public void StartCar()
    {
        //if (car != null)
        //{
        //    carPidController = car.GetComponentsInChildren<Transform>()[0].gameObject.GetComponentsInChildren<Transform>()[2].gameObject;
        //}
    }
}
