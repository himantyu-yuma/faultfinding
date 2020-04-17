using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousorTest : MonoBehaviour
{
    [SerializeField]
    private bool isDebug = false;

    private Material[] materials;
    [SerializeField]
    private Material outlineMaterial = default;

    private void Start()
    {
        materials = this.GetComponentInChildren<SkinnedMeshRenderer>().materials;
    }

    private void OnMouseEnter()
    {
        if (!isDebug)
        {
            return;
        }
        else
        {
            materials[materials.Length - 1] = outlineMaterial;
            this.GetComponentInChildren<SkinnedMeshRenderer>().materials = materials;
        }
    }
    private void OnMouseExit()
    {
        if (!isDebug)
        {
            return;
        }
        else
        {
            materials[materials.Length - 1] = null;
            this.GetComponentInChildren<SkinnedMeshRenderer>().materials = materials;
        }
    }
}
