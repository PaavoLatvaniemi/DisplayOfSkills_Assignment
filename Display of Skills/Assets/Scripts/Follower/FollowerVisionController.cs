using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerVisionController : MonoBehaviour
{
    public GameObject detectedTargetGO { get; private set; }
    public bool targetDetected { get; private set; }

    FieldOfView fieldOfView;

    private void Awake()
    {
        fieldOfView = GetComponentInChildren<FieldOfView>();
        fieldOfView.OnTargetDetected += Detect;
        fieldOfView.OnTargetLost += Undetect;
    }

    private void OnDestroy()
    {
        fieldOfView.OnTargetDetected -= Detect;
        fieldOfView.OnTargetLost -= Undetect;
    }

    void Detect(GameObject gameObject) 
    {
        detectedTargetGO = gameObject;
        targetDetected = true;
    }
    void Undetect() => targetDetected = false;

    public bool LineOfSightToTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, detectedTargetGO.transform.position - transform.position, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, detectedTargetGO.transform.position - transform.position);
            Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag(fieldOfView.targetTag)) return true;
        }
        return false;
    }
}
