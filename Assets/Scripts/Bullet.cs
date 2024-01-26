using System.Collections;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Bullet : MonoBehaviour
{
    [SerializeField] private FloatReference bulletVelocity;
    [SerializeField] private FloatReference bulletTimeOfLife;

    private void OnEnable()
    {
        StartCoroutine(AutoDestruction());
    }

    private void Update()
    {
        transform.position += transform.up * bulletVelocity.Value * Time.deltaTime;
    }

    private void Destroy()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(bulletTimeOfLife.Value);
        Destroy();
    }
}
