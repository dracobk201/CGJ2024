using UnityEngine;
using ScriptableObjectArchitecture;

public class ClownBulletMagazine : MonoBehaviour
{
    [SerializeField] private GameObjectCollection clownBullets;
    [SerializeField] private IntReference clownBulletsPool;
    [SerializeField] private GameObject clownBulletPrefab;

    private void Start()
    {
        clownBullets.Clear();
        InstantiateBullets();
    }

    private void InstantiateBullets()
    {
        for (int i = 0; i < clownBulletsPool.Value; i++)
        {
            GameObject bullet = Instantiate(clownBulletPrefab) as GameObject;
            bullet.GetComponent<Transform>().SetParent(transform);
            clownBullets.Add(bullet);
            bullet.SetActive(false);
        }
    }
}
