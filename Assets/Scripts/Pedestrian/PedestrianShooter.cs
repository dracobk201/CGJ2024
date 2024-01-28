using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianShooter : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode;
    [SerializeField] private GameObjectCollection pedestrians;
    private float platformWidth;

    private void Start()
    {
        Camera mainCam = Camera.main;
        double widthDouble = mainCam.orthographicSize * 2.0 * Screen.width / Screen.height;
        Vector3 upperLeftScreenWorld = mainCam.ViewportToWorldPoint(new Vector3(0, 1f, 0f));
        platformWidth = (float) widthDouble;
        transform.localScale = new Vector3(platformWidth, 0.1f, 1);
        transform.position = new Vector3(0, upperLeftScreenWorld.y+0.3f, 1);
        if (debugMode.Value)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void ShootPedestrian()
    {
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
