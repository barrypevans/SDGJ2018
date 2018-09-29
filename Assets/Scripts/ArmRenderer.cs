using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArmRenderer : MonoBehaviour
{

    private LineRenderer _lineRenderer;
    [SerializeField] private Transform[]  _joints;


    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3[] positions = new Vector3[_joints.Length];
        for (int i = 0; i < positions.Length; i++)
            positions[i] = _joints[i].position;
        _lineRenderer.positionCount = positions.Length;
        _lineRenderer.SetPositions(positions);
        
    }

}
