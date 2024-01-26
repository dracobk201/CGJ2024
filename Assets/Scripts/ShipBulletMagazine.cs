using UnityEngine;
using ScriptableObjectArchitecture;

public class ShipBulletMagazine : MonoBehaviour
{
    [SerializeField] private GameObjectCollection playerBullets;
    [SerializeField] private IntReference playerBulletsPool;
    [SerializeField] private GameObject playerBulletPrefab;

    private void Start()
    {
        playerBullets.Clear();
        InstantiateBullets();
    }

    private void InstantiateBullets()
    {
        for (int i = 0; i < playerBulletsPool.Value; i++)
        {
            GameObject bullet = Instantiate(playerBulletPrefab) as GameObject;
            bullet.GetComponent<Transform>().SetParent(transform);
            playerBullets.Add(bullet);
            bullet.SetActive(false);
        }
    }
}
