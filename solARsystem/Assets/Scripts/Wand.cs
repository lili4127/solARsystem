using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    MeshRenderer wandMesh;
    Material og;

    public Material collided;
    public Material selected;

    GameObject target;
    MeshRenderer targetMesh;
    Transform targetPos;


    // Start is called before the first frame update
    void Start()
    {
        wandMesh = this.GetComponent<MeshRenderer>();
        og = wandMesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        wandMesh.material = collided;
    }

    private void OnTriggerStay(Collider other)
    {
        wandMesh.material = collided;
    }

    private void OnTriggerExit(Collider other)
    {
        wandMesh.material = og;
        target = other.gameObject;
    }

    public void Selected()
    {
        wandMesh.material = selected;
        targetPos = target.transform;
        targetMesh = target.GetComponent<MeshRenderer>();
        targetMesh.material.EnableKeyword("_EMISSION");
    }

    public void Positioned()
    {
        target.transform.position = this.transform.position;
        targetMesh = target.GetComponent<MeshRenderer>();
        targetMesh.material.DisableKeyword("_EMISSION");
    }
}
