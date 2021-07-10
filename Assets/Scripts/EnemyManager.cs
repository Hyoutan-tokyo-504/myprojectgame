using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bosszombie;
    public GameObject reptile;
    public GameObject reptileboss;
    public GameObject bomberbug;
    public GameObject bomberbugboss;
    private ScoreManager scoremanager;
    private List<GameObject> EnemyList = new List<GameObject>();
    private List<GameObject> BossList = new List<GameObject>();
    private int score;
    public int money;
    private int count;
    private float spawninterval;
    private float bossspawninterval;
    // Start is called before the first frame update
    void Start()
    {
        scoremanager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        EnemyList.Add(zombie);
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyInstantiate();
        EnemylistRevise();
    }

    public void EnemyDead(int kind)
    {
        if (kind == 1)
        {
            score += 5;
            scoremanager.AddMoney(10);
        }
        if (kind == 2)
        {
            score += 15;
            scoremanager.AddMoney(50);
        }
        if (kind == 3)
        {
            score += 10;
            scoremanager.AddMoney(30);
        }
        if (kind == 4)
        {
            score += 30;
            scoremanager.AddMoney(100);
        }
        if (kind == 5)
        {
            score += 15;
            scoremanager.AddMoney(80);
        }
        if (kind == 6)
        {
            score += 50;
            scoremanager.AddMoney(150);
        }
    }

    void EnemyInstantiate()
    {
        spawninterval += Time.deltaTime;
        bossspawninterval += Time.deltaTime;
        if (spawninterval > 5.0f)
        {
            spawninterval = 0.0f;
            int number = Random.Range(0, EnemyList.Count);
            Instantiate(EnemyList[number], new Vector3(490, 4, 240) + new Vector3(1, 0, 0) * Random.Range(-10.0f, 10.0f), Quaternion.Euler(0, 180, 0));
        }
        if (bossspawninterval > 15.0f)
        {
            bossspawninterval = 0.0f;
            int number = Random.Range(0, BossList.Count);
            Instantiate(BossList[number], new Vector3(490, 4, 240) + new Vector3(1, 0, 0) * Random.Range(-10.0f, 10.0f), Quaternion.Euler(0, 180, 0));
        }
    }
    void EnemylistRevise()
    {
        if (score > 50 && count == 1)
        {   
            BossList.Add(bosszombie);
            count = 2;
        }
        if (score > 150 && count == 2)
        {
            EnemyList.Add(reptile);
            count = 3;
        }
        if (score > 350 && count == 3)
        {
            BossList.Add(reptileboss);
            count = 4;
        }
        if (score > 600 && count == 4)
        {
            EnemyList.Add(bomberbug);
            count = 5;
        }
        if (score > 1000 && count == 5)
        {
            BossList.Add(bomberbugboss);
            count = 6;
        }
        //if(leftbosszombiecount < 0.5 && leftzombiecount < 0.5)
        //{
        //    Debug.Log("clear");
        //}
    }
}
