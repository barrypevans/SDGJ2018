using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D _handRight;

    private void Update()
    {
        Vector2 velocityDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Mathf.Abs(velocityDirection.magnitude)>.1f)
            _handRight.velocity = velocityDirection.normalized * 10;
    }

}
