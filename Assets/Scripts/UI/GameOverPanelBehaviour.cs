using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelBehaviour : MonoBehaviour
{
    [SerializeField] private IntReference currentWave;
    [SerializeField] private TMP_Text currentWaveLabel;
    [SerializeField] private CanvasGroup panelCanvasGroup;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        currentWaveLabel.text = $"";
        ShowHidePanel(false);
    }

    private void OnEnable()
    {
        retryButton.onClick.AddListener(RetryGame);
    }

    private void OnDisable()
    {
        retryButton.onClick.RemoveListener(RetryGame);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPanel()
    {
        ShowHidePanel(true);
    }

    private void ShowHidePanel(bool isShowingPanel)
    {
        if (isShowingPanel)
        {
            panelCanvasGroup.alpha = 1;
            panelCanvasGroup.blocksRaycasts = true;
            panelCanvasGroup.interactable = true;
            currentWaveLabel.text = $"{currentWave.Value:000}";
        }
        else
        {
            panelCanvasGroup.alpha = 0;
            panelCanvasGroup.blocksRaycasts = false;
            panelCanvasGroup.interactable = false;
            currentWaveLabel.text = $"";
        }
    }
}
