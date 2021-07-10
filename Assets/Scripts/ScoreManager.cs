using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private int money = 0;
    private EnemyManager enemyManager;
    private Text scoreLabel;
    private Text moneyLabel;

    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        money = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().money;
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE：" + score;
        moneyLabel = GameObject.Find("MoneyLabel").GetComponent<Text>();
        moneyLabel.text = "Money：" + money;
    }

    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE：" + score;
    }

    public void AddMoney(int reward)
    {
        money += reward;
        moneyLabel.text = "MONEY：" + money;
    }
}

//public GameObject effectPrefab;
//public GameObject effectPrefab2;
//public int objectHP;
//public GameObject[] itemPrefabs;
