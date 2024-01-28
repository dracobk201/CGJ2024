using ScriptableObjectArchitecture;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;

    private void Awake()
    {
        isGameOver.Value = true;
    }

    public void BeginTrigger()
    {
        isGameOver.Value = false;
    }

    public void GameOverTrigger()
    {
        isGameOver.Value = true;
    }
}
