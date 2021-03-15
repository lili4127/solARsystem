using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orbit2 : MonoBehaviour
{
    Wand w;

    // Start is called before the first frame update
    void Start()
    {
        w = GetComponent<Wand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Clone"))
        {
            other.transform.parent = this.transform.parent.transform;
        }
    }
}
