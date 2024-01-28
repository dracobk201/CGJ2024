using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianFunness : MonoBehaviour
{
    [SerializeField] private IntReference remainingPedestrian;
    [SerializeField] private IntReference funnessThreshold;
    [SerializeField] private GameEvent deadPedestrian;
    [SerializeField] private Animator pedestrianAnimator;
    [SerializeField] private BoxCollider2D pedestrianCollider;
    [SerializeField] private AudioSource pedestrianAudioSource;
    [SerializeField] private AudioClip[] laughs;
    private bool pedestrianHappy;
    private int currentFunness;

    private void OnEnable()
    {
        currentFunness = funnessThreshold.Value;
        pedestrianHappy = false;
        pedestrianCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.BulletTag) && !pedestrianHappy)
        {
            currentFunness--;
            float currentPercentage = (float)currentFunness / funnessThreshold.Value;

            if (currentPercentage > 0.8f)
            {
                pedestrianAnimator.SetBool(Global.FirstChangePedestrian, true);
                if (Random.value >= 0.3)
                {
                    pedestrianAudioSource.PlayOneShot(laughs[0]);
                }
            }
            else if (currentPercentage <= 0.8f && currentPercentage >= 0.4f)
            {
                pedestrianAnimator.SetBool(Global.FirstChangePedestrian, true);
                pedestrianAnimator.SetBool(Global.SecondChangePedestrian, true);
                if (Random.value >= 0.4)
                {
                    pedestrianAudioSource.PlayOneShot(laughs[0]);
                }
            }
            else if (currentPercentage <= 0.4f && currentPercentage >= 0f)
            {
                pedestrianAnimator.SetBool(Global.FirstChangePedestrian, true);
                pedestrianAnimator.SetBool(Global.SecondChangePedestrian, true);
                pedestrianAnimator.SetBool(Global.ThirdChangePedestrian, true);
                if (Random.value >= 0.5)
                {
                    pedestrianAudioSource.PlayOneShot(laughs[0]);
                }
            }
            else if (currentPercentage <= 0)
            {
                if (Random.value >= 0.3)
                {
                    pedestrianAudioSource.PlayOneShot(laughs[Random.Range(1, laughs.Length)]);
                }
                pedestrianHappy = true;
                deadPedestrian.Raise();
                pedestrianAnimator.SetBool(Global.ExplodePedestrian, true);
                pedestrianCollider.enabled = false;
                remainingPedestrian.Value = Mathf.Clamp(remainingPedestrian.Value - 1, 0, 9999);
            }
        }
    }
}
