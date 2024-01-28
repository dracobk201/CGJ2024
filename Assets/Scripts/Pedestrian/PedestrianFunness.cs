using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianFunness : MonoBehaviour
{
    [SerializeField] private IntReference remainingPedestrian;
    [SerializeField] private IntReference funnessThreshold;
    [SerializeField] private Animator pedestrianAnimator;
    [SerializeField] private BoxCollider2D pedestrianCollider;
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
            float currentPercentage = currentFunness / funnessThreshold.Value;

            if (currentPercentage > 0.8f)
            {
                if (pedestrianAnimator == null) return;
                pedestrianAnimator.SetBool(Global.FirstStatePedestrian, true);
                //pedestrianAnimator.SetBool(Global.SecondStatePedestrian, false);
                //pedestrianAnimator.SetBool(Global.ThirdStatePedestrian, false);
            }
            else if (currentPercentage <= 0.8f && currentPercentage >= 0.4f)
            {
                if (pedestrianAnimator == null) return;
                pedestrianAnimator.SetBool(Global.FirstStatePedestrian, true);
                pedestrianAnimator.SetBool(Global.SecondStatePedestrian, true);
                //pedestrianAnimator.SetBool(Global.ThirdStatePedestrian, false);
            }
            else if (currentPercentage <= 0.4f && currentPercentage >= 0f)
            {
                if (pedestrianAnimator == null) return;
                pedestrianAnimator.SetBool(Global.FirstStatePedestrian, true);
                pedestrianAnimator.SetBool(Global.SecondStatePedestrian, true);
                pedestrianAnimator.SetBool(Global.ThirdStatePedestrian, true);
            }
            else if (currentPercentage <= 0)
            {
                pedestrianHappy = true;
                if (pedestrianAnimator != null)
                {
                    pedestrianAnimator.SetBool(Global.ExplodePedestrian, true);
                }
                pedestrianCollider.enabled = false;
                remainingPedestrian.Value = Mathf.Clamp(remainingPedestrian.Value - 1, 0, 9999);
            }
        }
    }
}
