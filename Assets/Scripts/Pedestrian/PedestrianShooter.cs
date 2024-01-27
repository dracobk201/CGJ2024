using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianShooter : MonoBehaviour
{
    [SerializeField] private FloatReference pedestrianRPM;
    [SerializeField] private GameObjectCollection pedestrians;
    private float platformWidth;
    private float nextShot = 0;

    private void Start()
    {
        Camera mainCam = Camera.main;
        double widthDouble = mainCam.orthographicSize * 2.0 * Screen.width / Screen.height;
        Vector3 upperLeftScreenWorld = mainCam.ViewportToWorldPoint(new Vector3(0, 1f, 0f));
        platformWidth = (float) widthDouble;
        transform.localScale = new Vector3(platformWidth, 0.1f, 1);
        transform.position = new Vector3(0, upperLeftScreenWorld.y+0.5f, 1);
    }

    private void Update()
    {
        ShootPedestrian();
    }

    private void ShootPedestrian()
    {
        if (Time.time < nextShot) return;
        nextShot = Time.time + 60 / pedestrianRPM.Value;
        var initialRotation = transform.rotation;

        for (int i = 0; i < pedestrians.Count; i++)
        {
            if (!pedestrians[i].activeInHierarchy)
            {
                pedestrians[i].transform.localPosition = RandomPosition();
                pedestrians[i].transform.localRotation = initialRotation;
                pedestrians[i].SetActive(true);
                break;
            }
        }
    }

    private Vector2 RandomPosition()
    {
        var position = Vector2.zero;
        position.x = Random.Range(-platformWidth, platformWidth)/2;
        position.y = transform.position.y;
        return position;
    } 

}
