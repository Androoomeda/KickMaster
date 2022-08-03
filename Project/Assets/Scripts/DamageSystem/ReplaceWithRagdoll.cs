using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceWithRagdoll : MonoBehaviour
{
    [SerializeField] private GameObject ragdoll;

    public void Replace()
    {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
