using ScriptableObjectArchitecture;
using System;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] private BoolReference isGameOver;
    [SerializeField] private Vector2Reference movement;
    [SerializeField] private Animator clownAnimator;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (isGameOver.Value) return;
        if (movement.Value != Vector2.zero)
        {
            Vector2 cameraPosition = mainCamera.ScreenToWorldPoint(new Vector3(movement.Value.x, movement.Value.y, mainCamera.nearClipPlane));
            float x = Mathf.Lerp(transform.position.x, cameraPosition.x, Time.deltaTime * 2);
            float y = Mathf.Lerp(transform.position.y, cameraPosition.y, Time.deltaTime * 2);
            Vector3 newPosition = new Vector3(x, y, 0);

            var heading = newPosition - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            ChangeAnimation(direction);

            transform.position = newPosition;
        }
    }

    private void ChangeAnimation(Vector3 direction)
    {
        if (direction.x < -0.3f)
        {
            clownAnimator.SetBool(Global.LeftClown, true);
            clownAnimator.SetBool(Global.RightClown, false);
        }
        else if (direction.x > 0.3f)
        {
            clownAnimator.SetBool(Global.LeftClown, false);
            clownAnimator.SetBool(Global.RightClown, true);
        }
        else
        {
            clownAnimator.SetBool(Global.LeftClown, false);
            clownAnimator.SetBool(Global.RightClown, false);
        }
    }
}
