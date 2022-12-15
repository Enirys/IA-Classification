using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuController : MonoBehaviour
{
    public static HomeMenuController Instance;
    public GameObject SensorModel { get; set; }
    private GameObject _sensorModel;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ViewSensorModel()
    {
        if (SensorModel != null)
            _sensorModel = Instantiate(SensorModel, SensorModel.transform.position, Quaternion.identity);
    }

    public void CloseSensorModel()
    {
        Destroy(_sensorModel);
    }
}
