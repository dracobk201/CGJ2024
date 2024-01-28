using ScriptableObjectArchitecture;
using UnityEngine;

public class ClownWeapon : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;
    [SerializeField] private BoolReference isShooting;
    [SerializeField] private FloatReference bulletRPM;
    [SerializeField] private GameObjectCollection clownBullets;
    private float nextShot = 0;

    private void Update()
    {
        ShootBullet();
    }

    private void ShootBullet()
    {
        if (!isShooting.Value || Time.time < nextShot || isGameOver.Value) return;
        nextShot = Time.time + 60 / bulletRPM.Value;
        var initialPosition = transform.position;
        var initialRotation = transform.rotation;

        for (int i = 0; i < clownBullets.Count; i++)
        {
            if (!clownBullets[i].activeInHierarchy)
            {
                clownBullets[i].transform.localPosition = initialPosition;
                clownBullets[i].transform.localRotation = initialRotation;
                clownBullets[i].SetActive(true);
                break;
            }
        }
    }
}
