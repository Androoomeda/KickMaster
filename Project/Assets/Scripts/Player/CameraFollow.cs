using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0, 0, 0.1f);

    private void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = targetPos;
    }
}
