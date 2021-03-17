using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 25 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sun")
        {
            this.transform.parent = other.gameObject.transform;
            this.transform.position = other.gameObject.transform.position;
        }

        if (other.gameObject.name.Contains("Clone") && !other.gameObject.name.Contains("orbit"))
        {
            other.gameObject.transform.parent = this.transform;
        }
    }
}
