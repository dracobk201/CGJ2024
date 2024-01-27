using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianFunness : MonoBehaviour
{
    [SerializeField] private IntReference funnessThreshold;
    [SerializeField] private SpriteRenderer pedestrianSpriteRenderer;
    private bool pedestrianHappy;
    private int currentFunness;

    private void OnEnable()
    {
        currentFunness = funnessThreshold.Value;
        pedestrianHappy = false;
    }

    private void Update()
    {
        Debug.Log((float)currentFunness / funnessThreshold.Value);
        pedestrianSpriteRenderer.color = Color.Lerp(Color.red, Color.blue, (float)currentFunness / funnessThreshold.Value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.BulletTag) && !pedestrianHappy)
        {
            currentFunness--;
            if (currentFunness <= 0)
            {
                pedestrianHappy = true;
            }
        }
    }
}
