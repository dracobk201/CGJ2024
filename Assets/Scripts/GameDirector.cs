using ScriptableObjectArchitecture;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;
    [SerializeField] private AudioSource gameDirectorAudioSource;
    [SerializeField] private AudioClip[] sounds;

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
        PlaySoundAtRandom();
        isGameOver.Value = true;
    }

    private void PlaySoundAtRandom()
    {
        int index = Random.value >= 0.5 ? 1 : 0;
        var clip = sounds[index];
        gameDirectorAudioSource.PlayOneShot(clip);
    }
}
