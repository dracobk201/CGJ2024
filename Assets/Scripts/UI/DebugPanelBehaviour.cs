using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class DebugPanelBehaviour : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode;
    [SerializeField] private TMP_Text debugText;

    #region Wave Manager
    [SerializeField] private IntReference currentWave;
    [SerializeField] private IntReference currentPedestrianToSend;
    [SerializeField] private IntReference remainingPedestrian;
    [SerializeField] private FloatReference currentTimeToSend;
    #endregion

    private void Start()
    {
        debugText.text = string.Empty;
    }

    private void Update()
    {
        if (debugMode.Value)
        {
            debugText.text = "WaveManager \n";
            debugText.text += $"Wave: {currentWave.Value}\n";
            debugText.text += $"P Amount: {currentPedestrianToSend.Value}\n";
            debugText.text += $"Remaining P: {remainingPedestrian.Value}\n";
            debugText.text += $"Next P in: {currentTimeToSend.Value}\n";

        }
    }
}
