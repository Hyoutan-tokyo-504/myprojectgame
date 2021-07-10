using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public void StopGame()
    //{
    //    Time.timeScale = 0f;
    //}
    public GameObject PauseUIprehab;
    private Slider HPslider;
    private Text HPLabel;
    private EnemyManager enemymanager;
    private HPManager hpmanager;
    private BoundaryController boundarycontroller;
    public GameObject machingun;
    private GameObject PauseUIinstance;
    bool pause = false;
    void Start()
    {
        PauseUIprehab.SetActive(false);
        //HPslider = GameObject.Find("HPbar").GetComponent<Slider>();
        //HPLabel = GameObject.Find("HPLabel").GetComponent<Text>();
        enemymanager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        hpmanager = GameObject.Find("HPManager").GetComponent<HPManager>();
        boundarycontroller = GameObject.Find("BoundaryController").GetComponent<BoundaryController>();
        enemymanager.money = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if(pause == true)
        {
            Time.timeScale = 0f;
        }
    }

    public void PauseButtonDown()
    {
        pause = true;
        PauseUIprehab.SetActive(true);
    }

    public void RestartButtonDown()
    {
        pause = false;
        Time.timeScale = 1.0f;
        PauseUIprehab.SetActive(false);
    }

    public void ReinforceButton()
    {
        int money = enemymanager.money;
        if(money > 300)
        {
            boundarycontroller.HPreinforce(100);
            money -= 300;
        }
        else
        {

        }
    }



}
