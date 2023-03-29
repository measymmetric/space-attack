using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    GameObject sheild;

    private void Start()
    {
        sheild = transform.Find("sheild").gameObject;
    }

    void Update()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
        }
    }

    void ActivateSheild()
    {
        sheild.SetActive(true);
    }

    void DeactivateSheild()
    {
        sheild.SetActive(false);
    }
}
