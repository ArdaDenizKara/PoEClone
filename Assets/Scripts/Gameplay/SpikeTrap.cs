using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject spikeTrap;
    bool isGameActive;
    private void Start()
    {
        isGameActive = true;
        StartCoroutine(spikeTrapCoroutine());
    }
    IEnumerator spikeTrapCoroutine()
    {
        while (isGameActive)
        {
            spikeTrap.SetActive(true);
            yield return new WaitForSeconds(2);
            spikeTrap.SetActive(false);
            yield return new WaitForSeconds(2);
        }
    }
}
