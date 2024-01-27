using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianMagazine : MonoBehaviour
{
    [SerializeField] private GameObjectCollection pedestrians;
    [SerializeField] private IntReference pedestrianPool;
    [SerializeField] private GameObject pedestrianPrefab;

    private void Start()
    {
        pedestrians.Clear();
        InstantiatePedestrians();
    }

    private void InstantiatePedestrians()
    {
        for (int i = 0; i < pedestrianPool.Value; i++)
        {
            GameObject pedestrian = Instantiate(pedestrianPrefab) as GameObject;
            pedestrian.GetComponent<Transform>().SetParent(transform);
            pedestrians.Add(pedestrian);
            pedestrian.SetActive(false);
        }
    }
}
