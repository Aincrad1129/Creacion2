using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void EventHandler();
    public event EventHandler CollideWithPlayerEnter;
    public event EventHandler CollideWithPlayerExit;


    // Checking a reference to a collider is better than using strings.
    [SerializeField] Collider playerCollider;


    void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider || playerCollider == null) CollideWithPlayerEnter();
    }


    void OnTriggerExit(Collider collider)
    {
        if (collider == playerCollider || playerCollider == null) CollideWithPlayerExit();
    }
}
