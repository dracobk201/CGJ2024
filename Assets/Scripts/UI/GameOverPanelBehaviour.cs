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
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private AudioClip[] farts;
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
        PlaySoundAtRandom(); 
        SceneManager.LoadScene(0);
    }

    private void PlaySoundAtRandom()
    {
        int index = Random.value >= 0.5 ? 1 : 0;
        var clip = farts[index];
        gameOverAudioSource.PlayOneShot(clip);
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
