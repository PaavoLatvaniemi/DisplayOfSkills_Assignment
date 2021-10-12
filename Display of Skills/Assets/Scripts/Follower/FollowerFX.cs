using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFX : MonoBehaviour
{
    [SerializeField] GameObject idleGO;
    [SerializeField] GameObject chaseGO;
    [SerializeField] GameObject searchGO;

    public void ChangeToIdle()
    {
        DisableAll();
        idleGO.SetActive(true);
    }

    public void ChangeToChase()
    {
        DisableAll();
        chaseGO.SetActive(true);
    }

    public void ChangeToSearch()
    {
        DisableAll();
        searchGO.SetActive(true);
    }

    void DisableAll()
    {
        idleGO.SetActive(false);
        chaseGO.SetActive(false);
        searchGO.SetActive(false);
    }
}
