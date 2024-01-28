using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeController : MonoBehaviour
{
    [SerializeField] private FloatReference lowShakeMagnitude;
    [SerializeField] private FloatReference heavyShakeMagnitude;
    [SerializeField] private FloatReference lowShakeDuration;
    [SerializeField] private FloatReference heavyShakeDuration;
    [SerializeField] private FloatReference shakeDampingSpeed;
    private float _shakeDuration;
    private float _shakeMagnitude;
    private float _dampingSpeed;
    private Vector3 _initialPosition;

    private void OnEnable()
    {
        _initialPosition = transform.localPosition;
        _dampingSpeed = shakeDampingSpeed.Value;
    }

    private void Update()
    {
        if (_shakeDuration > 0)
        {
            transform.localPosition = _initialPosition + Random.insideUnitSphere * _shakeMagnitude;
            _shakeDuration -= Time.deltaTime * _dampingSpeed;
        }
        else
        {
            _shakeDuration = 0f;
            transform.localPosition = _initialPosition;
        }
    }

    public void TriggerSimpleShake()
    {
        _shakeDuration = lowShakeDuration.Value;
        _shakeMagnitude = lowShakeMagnitude.Value;
    }

    public void TriggerHardShake()
    {
        _shakeDuration = heavyShakeDuration.Value;
        _shakeMagnitude = heavyShakeMagnitude.Value;
    }
}
