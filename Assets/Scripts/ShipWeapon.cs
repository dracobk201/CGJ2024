using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private BoolReference isShooting;
    [SerializeField] private FloatReference RPM;
    [SerializeField] private GameObjectCollection playerBullets;
    private float _nextShot = 0;

    private void Update()
    {
        ShootBullet();
    }

    public void ShootBullet()
    {
        if (!isShooting.Value || Time.time < _nextShot) return;
        _nextShot = Time.time + 60 / RPM.Value;
        var initialPosition = transform.position;
        var initialRotation = transform.rotation;

        for (int i = 0; i < playerBullets.Count; i++)
        {
            if (!playerBullets[i].activeInHierarchy)
            {
                playerBullets[i].transform.localPosition = initialPosition;
                playerBullets[i].transform.localRotation = initialRotation;
                playerBullets[i].SetActive(true);
                break;
            }
        }
    }
}
