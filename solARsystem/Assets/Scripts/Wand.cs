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
    GameObject currentTarget;
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
        currentTarget = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        wandMesh.material = og;
    }

    public void Selected()
    {
        if(wandMesh.material != selected)
        {
            wandMesh.material = selected;
            target = currentTarget;
            targetPos = target.transform;
        }
        else
        {
            wandMesh.material = og;
        }
    }

    public void Positioned()
    {
        target.transform.position = this.transform.position;
        wandMesh.material = og;
    }
}
