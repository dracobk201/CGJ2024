using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelBehaviour : MonoBehaviour
{
    [SerializeField] private GameEvent beginGame;
    [SerializeField] private CanvasGroup panelCanvasGroup;
    [SerializeField] private Button beginButton;

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
        beginGame.Raise();
    }

    public void HidePanel()
    {
        ShowHidePanel(false);
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
