using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * 10 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "OnCollision")
        {
            Debug.Log(col.gameObject.tag);
        }
    }

}
