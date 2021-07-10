using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    bool retry;
    // Start is called before the first frame update
    void Start()
    {
        retry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(retry == true)
        {
            SceneManager.LoadScene("OpenScene");
        }
    }
    public void RetryButtonDown()
    {
        retry = true;
    }
}
