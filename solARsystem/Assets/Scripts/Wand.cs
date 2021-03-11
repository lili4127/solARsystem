using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Material collided;
    public Material selected;
    public GameObject target;
    Transform pos;

    MeshRenderer msh;
    Material og;

    // Start is called before the first frame update
    void Start()
    {
        msh = this.GetComponent<MeshRenderer>();
        og = msh.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        msh.material = collided;
        target = collision.gameObject;
    }

    private void OnCollisionStay(Collision collision)
    {
        msh.material = collided;
        target = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        msh.material = og;
    }

    public void Selected()
    {
        msh.material = selected;
        pos = target.transform;

    }

    public void Positioned()
    {
        target.transform.position = this.transform.position;
    }
}
