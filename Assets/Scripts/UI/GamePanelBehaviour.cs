using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class GamePanelBehaviour : MonoBehaviour
{
    [SerializeField] private IntReference currentWave;
    [SerializeField] private TMP_Text currentWaveLabel;
    private int previousValue;

    private void Start()
    {
        previousValue = 0;
        currentWaveLabel.text = $"";
    }

    private void Update()
    {
        if (previousValue == currentWave.Value) return;
        if (currentWave.Value >= 0)
        {
            currentWaveLabel.text = $"Wave\n{currentWave.Value:000}";
            previousValue = currentWave.Value;
        }
        else
        {
            currentWaveLabel.text = $"";
        }
    }
}
