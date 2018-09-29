using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
    [SerializeField] private float _radius = 1;
    [SerializeField] private Transform[] _targets ;
    private Vector3 _center;

    private void Awake()
    {
        _center = transform.position;
    }

    private void Update()
    {
        Vector3 lookPosition =  Vector3.zero;
        for (int i = 0; i < _targets.Length; i++)
            lookPosition += _targets[i].position;
        lookPosition /= (float)_targets.Length;
        transform.position = _center + (lookPosition - _center).normalized * _radius;
    }

}
