using ScriptableObjectArchitecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private IntReference currentWave;
    [SerializeField] private IntReference initialPedestrianToSend;
    [SerializeField] private FloatReference pedestrianStepToSend;
    [SerializeField] private IntReference remainingPedestrian;
    [SerializeField] private FloatReference initialTimeToSend;
    [SerializeField] private FloatReference initialStepTime;
    [SerializeField] private GameEvent sendPedestrian;
    [SerializeField] private IntReference currentPedestrianToSend;
    [SerializeField] private FloatReference currentTimeToSend;

    private void Start()
    {
        currentWave.Value = 0;
        ChangeWave();
    }

    private void Update()
    {
        if (remainingPedestrian.Value <= 0)
        {
            ChangeWave();
        }
        WaveChecker();
    }

    private void WaveChecker()
    {
        currentTimeToSend.Value -= Time.deltaTime;
        if (currentTimeToSend.Value <= 0 && currentPedestrianToSend.Value > 0)
        {
            sendPedestrian.Raise();
            currentPedestrianToSend.Value--;
            currentTimeToSend.Value = initialTimeToSend.Value - (initialStepTime.Value * currentWave.Value);
        }
    }

    private void ChangeWave()
    {
        currentWave.Value++;
        int roundedValue = Mathf.RoundToInt(pedestrianStepToSend.Value * currentWave.Value);
        currentPedestrianToSend.Value = initialPedestrianToSend.Value + roundedValue;
        remainingPedestrian.Value = currentPedestrianToSend.Value;
        currentTimeToSend.Value = initialTimeToSend.Value - (initialStepTime.Value * currentWave.Value);
    }
}
