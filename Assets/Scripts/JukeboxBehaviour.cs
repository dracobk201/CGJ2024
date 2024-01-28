using UnityEngine;

public class JukeboxBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource jukeboxAudioSource;
    [SerializeField] private AudioClip[] songs;

    private void Start()
    {
        ChangeBGM();
    }

    public void ChangeBGM()
    {
        int index = Random.Range(0, songs.Length);
        var clip = songs[index];
        jukeboxAudioSource.clip = clip;
        jukeboxAudioSource.Play();
    }
}
