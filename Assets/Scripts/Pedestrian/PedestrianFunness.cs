using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianFunness : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode;
    [SerializeField] private IntReference remainingPedestrian;
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
        if (debugMode.Value)
        {
            pedestrianSpriteRenderer.color = Color.Lerp(Color.red, Color.blue, (float)currentFunness / funnessThreshold.Value);
        }
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
                remainingPedestrian.Value = Mathf.Clamp(remainingPedestrian.Value - 1, 0, 9999);
            }
        }
    }
}
