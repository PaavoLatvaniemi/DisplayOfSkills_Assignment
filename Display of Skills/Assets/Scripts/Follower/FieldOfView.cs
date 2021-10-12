using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public string targetTag = "Player";
    public event Action<GameObject> OnTargetDetected;
    public event Action OnTargetLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            OnTargetDetected?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            OnTargetLost?.Invoke();
        }
    }
}
