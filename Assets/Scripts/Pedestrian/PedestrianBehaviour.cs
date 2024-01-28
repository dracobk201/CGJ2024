using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class PedestrianBehaviour : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;
    [SerializeField] private FloatReference pedestrianMinVelocity;
    [SerializeField] private FloatReference pedestrianMaxVelocity;
    [SerializeField] private FloatReference pedestrianTimeOfLife;
    private float pedestrianVelocity;

    private void OnEnable()
    {
        StartCoroutine(AutoDestruction());
        pedestrianVelocity = Random.Range(pedestrianMinVelocity.Value, pedestrianMaxVelocity.Value);
    }

    private void Update()
    {
        if (!isGameOver.Value)
        {
            transform.position += pedestrianVelocity * Time.deltaTime * -transform.up;
        }
    }

    private void Destroy()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(pedestrianTimeOfLife.Value);
        Destroy();
    }
}
