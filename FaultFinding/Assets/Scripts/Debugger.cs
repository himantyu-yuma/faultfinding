using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private DebugMaster debugMaster;

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private MeshRenderer meshRenderer;
    private Material[] materials;
    [SerializeField]
    private Material outlineMaterial = default;

    // Start is called before the first frame update
    void Start()
    {
        debugMaster = GameObject.FindGameObjectWithTag("Master").GetComponent<DebugMaster>();
        if (this.GetComponentInChildren<SkinnedMeshRenderer>())
        {
            skinnedMeshRenderer = this.GetComponentInChildren<SkinnedMeshRenderer>();
            materials = this.GetComponentInChildren<SkinnedMeshRenderer>().materials;
        }else if (this.GetComponentInChildren<MeshRenderer>())
        {
            meshRenderer = this.GetComponentInChildren<MeshRenderer>();
            materials = this.GetComponentInChildren<MeshRenderer>().materials;
        }
    }

    private void Update()
    {
        if (debugMaster.isDebug)
        {
            return;
        }
        else
        {
            if(materials.Length == 0)
            {
                return;
            }
            materials[materials.Length - 1] = null;
            if (skinnedMeshRenderer)
            {
                skinnedMeshRenderer.materials = materials;
            }
            else if (meshRenderer)
            {
                meshRenderer.materials = materials;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!debugMaster.isDebug)
        {
            return;
        }
        else
        {
            materials[materials.Length - 1] = outlineMaterial;
            if (skinnedMeshRenderer)
            {
                skinnedMeshRenderer.materials = materials;
            }else if (meshRenderer)
            {
                meshRenderer.materials = materials;
            }
        }
    }
    private void OnMouseExit()
    {
        if (!debugMaster.isDebug)
        {
            return;
        }
        else
        {
            materials[materials.Length - 1] = null;
            if (skinnedMeshRenderer)
            {
                skinnedMeshRenderer.materials = materials;
            }
            else if (meshRenderer)
            {
                meshRenderer.materials = materials;
            }
        }
    }

    public void OnMouseDown()
    {
        if (!debugMaster.isDebug)
        {
            return;
        }
        else
        {
            this.GetComponentInChildren<IBugable>().BugFix();
        }
    }
}
