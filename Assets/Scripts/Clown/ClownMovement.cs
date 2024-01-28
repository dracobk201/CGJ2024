using ScriptableObjectArchitecture;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;
    [SerializeField] private Vector2Reference movement;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!isGameOver.Value)
        {
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(movement.Value.x, movement.Value.y, mainCamera.nearClipPlane));
        }
    }
}
