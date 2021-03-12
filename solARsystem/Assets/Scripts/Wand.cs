using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    MeshRenderer wandMesh;
    Material og;

    public Material collided;
    public Material selected;
    bool select;

    GameObject currentTarget;
    Transform p;
    Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        wandMesh = this.GetComponent<MeshRenderer>();
        og = wandMesh.material;
        p = this.transform.parent;
        spawnPos = p.GetChild(0);
        select = false;
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
        select = true;
        GameObject spawned;
        spawned = Instantiate(currentTarget, spawnPos, true) as GameObject;
        spawned.SetActive(true);     
    }

    public void Positioned()
    {
        if (select)
        {
            print("hi");
        }
        wandMesh.material = og;
    }
}
