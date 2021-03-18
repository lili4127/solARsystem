using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wand : MonoBehaviour
{
    MeshRenderer wandMesh;
    Material og;

    public Material collided;

    public Button sel;
    bool se;

    public Button pos;
    public bool p;

    public Button rot;
    public bool r;

    public Button sca;
    public bool sc;
    //scaling variables
    float scaleRate = 0.3f;
    float minScale = 1f;
    float maxScale = 2f;
    float speed = 2f;

    public Button del;
    bool d;
    public Material deletion;

    public Button toggleOrbit;
    bool orbitVisible;

    public Button orbitSpeed;
    public bool sp;
    //orbit speed variables
    float speedRate = 2f;
    float minSpeed = 20f;
    float maxSpeed = 80f;
    public float orbitSpeedValue = 30f;

    //Wand's current collision target and gameobject
    GameObject currentTarget;
    public GameObject selected;
    Transform par;
    Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //set wand color and spawn position at tip
        wandMesh = this.GetComponent<MeshRenderer>();
        og = wandMesh.material;
        par = this.transform.parent;
        spawnPos = par.GetChild(0);

        //initialize button values
        se = false;
        p = false;
        r = false;
        sc = false;
        d = false;
        orbitVisible = true;
        toggleOrbit.GetComponent<Image>().color = Color.green;
        sp = false;
    }

    // Update is called once per frame
    void Update()
    {
        //make wand red if delete button is active
        if (d)
        {
            wandMesh.material = deletion;
        }

        //make orbits invisible if orbit toggle is off
        if (!orbitVisible)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("orbitclone"))
            {
                o.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    //change wand color if colliding with something
    private void OnTriggerEnter(Collider other)
    {
        wandMesh.material = collided;
        currentTarget = other.gameObject;
    }

    //grab game object wand is continuing to collide with and perform functions based on active toggles
    private void OnTriggerStay(Collider other)
    {
        wandMesh.material = collided;
        currentTarget = other.gameObject;

        if (d && other.gameObject.name.Contains("Clone"))
        {
            Destroy(other.gameObject);
        }

        if (p && other.gameObject.name.Contains("Clone"))
        {
            currentTarget.transform.parent = spawnPos.transform;
        }

        if (r && other.gameObject.name.Contains("Clone"))
        {
            currentTarget.transform.rotation = spawnPos.transform.rotation;
        }

        if (sc && other.gameObject.name.Contains("Clone"))
        {
            Scale(other.gameObject);
        }

        if (sp && other.gameObject.tag == "orbitclone")
        {
            SpeedUp();
        }
    }

    //return wand to original color once not colliding
    private void OnTriggerExit(Collider other)
    {
        wandMesh.material = og;
    }

    public void Selected()
    {
        //instantiate and tag clones of orbits, planets, and moons if selected
        if (!se)
        {
            se = true;
            sel.GetComponent<Image>().color = Color.green;

            if(currentTarget.tag == "orbit")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "orbitclone";
            }

            else if (currentTarget.tag == "planet" || currentTarget.tag == "planetclone")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "planetclone";
            }

            else if (currentTarget.tag == "moon" || currentTarget.tag == "moonclone")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "moonclone";
            }

        }

        //exit select mode
        else if (se)
        {
            se = false;
            sel.GetComponent<Image>().color = Color.white;
        }
    }

    public void Positioned()
    {
        //enter position mode
        if (!p)
        {
            se = false;
            sel.GetComponent<Image>().color = Color.white;
            p = true;
            pos.GetComponent<Image>().color = Color.green; 
        }

        //exit position mode
        else if (p)
        {
            p = false;
            pos.GetComponent<Image>().color = Color.white;
        }
    }

    public void Rotated()
    {
        //enter rotation mode
        if (!r)
        {
            r = true;
            rot.GetComponent<Image>().color = Color.green;
        }

        //exit rotation mode
        else if (r)
        {
            r = false;
            rot.GetComponent<Image>().color = Color.white;
        }
    }

    public void Scaled()
    {
        //enter scale mode
        if (!sc)
        {
            sc = true;
            sca.GetComponent<Image>().color = Color.green;
        }

        //exit scale mode
        else if (sc)
        {
            sc = false;
            sca.GetComponent<Image>().color = Color.white;
        }
    }

    //change scale of gameobject
    void ApplyScaleRate(GameObject g)
    {
        g.transform.localScale += Vector3.one * scaleRate * Time.deltaTime * speed;
    }

    //scale the orbit larger or smaller based on its current size
    void Scale(GameObject g)
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (g.transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (g.transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate(g);
    }

    public void Deleted()
    {
        //enter delete mode and change wand color
        if (!d)
        {
            d = true;
            del.GetComponent<Image>().color = Color.green;
            wandMesh.material = deletion;
        }

        //exit delete mode
        else if (d)
        {
            d = false;
            del.GetComponent<Image>().color = Color.white;
        }
    }

    public void ToggleOrbit()
    {
        //enter active orbits mode (orbits can be seen)
        if (!orbitVisible)
        {
            orbitVisible = true;
            toggleOrbit.GetComponent<Image>().color = Color.green;

            foreach (GameObject o in GameObject.FindGameObjectsWithTag("orbitclone"))
            {
                o.GetComponent<Renderer>().enabled = true;
            }    
        }

        //exit active orbits mode
        else if (orbitVisible)
        {
            orbitVisible = false;
            toggleOrbit.GetComponent<Image>().color = Color.white;
        }
    }

    public void Speed()
    {
        //enter speed mode
        if (!sp)
        {
            sp = true;
            orbitSpeed.GetComponent<Image>().color = Color.green;
        }

        //exit speed mode
        else if (sp)
        {
            sp = false;
            orbitSpeed.GetComponent<Image>().color = Color.white;
        }
    }

    //change speed
    void ApplySpeedRate()
    {
        orbitSpeedValue += 2 * speedRate * Time.deltaTime;
    }

    //increase or decrease orbit speed based on its current speed
    void SpeedUp()
    {
        //if we exceed the defined speed then correct the sign of speed.
        if (orbitSpeedValue < minSpeed)
        {
            speedRate = Mathf.Abs(speedRate);
        }
        else if (orbitSpeedValue > maxSpeed)
        {
            speedRate = -Mathf.Abs(speedRate);
        }
        ApplySpeedRate();
    }


}
