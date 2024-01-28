using ScriptableObjectArchitecture;
using UnityEngine;

public class PedestrianCatcher : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode;
    [SerializeField] private IntReference currentPedestrianToSend;
    [SerializeField] private GameEvent gameOver;

    private void Start()
    {
        Camera mainCam = Camera.main;
        double widthDouble = mainCam.orthographicSize * 2.0 * Screen.width / Screen.height;
        Vector3 upperLeftScreenWorld = mainCam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        var platformWidth = (float)widthDouble;
        transform.localScale = new Vector3(platformWidth+3, 0.1f, 1);
        transform.position = new Vector3(0, upperLeftScreenWorld .y, 1);
        if (debugMode.Value)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string targetTag = other.tag;

        if (targetTag.Equals(Global.PedestrianTag) && currentPedestrianToSend.Value <= 0)
        {
            gameOver.Raise();
        }
    }
}
