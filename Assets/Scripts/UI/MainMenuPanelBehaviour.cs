using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelBehaviour : MonoBehaviour
{
    [SerializeField] private GameEvent beginGame;
    [SerializeField] private CanvasGroup panelCanvasGroup;
    [SerializeField] private Button beginButton;
    [SerializeField] private AudioSource mainMenuAudioSource;
    [SerializeField] private AudioClip[] farts;

    private void Start()
    {
        ShowHidePanel(true);
    }

    private void OnEnable()
    {
        beginButton.onClick.AddListener(RetryGame);
    }

    private void OnDisable()
    {
        beginButton.onClick.RemoveListener(RetryGame);
    }

    public void RetryGame()
    {
        HidePanel();
        PlaySoundAtRandom();
        beginGame.Raise();
    }

    public void HidePanel()
    {
        ShowHidePanel(false);
    }

    private void PlaySoundAtRandom()
    {
        int index = Random.value >= 0.5 ? 1 : 0;
        var clip = farts[index];
        mainMenuAudioSource.PlayOneShot(clip);
    }

    private void ShowHidePanel(bool isShowingPanel)
    {
        if (isShowingPanel)
        {
            panelCanvasGroup.alpha = 1;
            panelCanvasGroup.blocksRaycasts = true;
            panelCanvasGroup.interactable = true;
        }
        else
        {
            panelCanvasGroup.alpha = 0;
            panelCanvasGroup.blocksRaycasts = false;
            panelCanvasGroup.interactable = false;
        }
    }


}
