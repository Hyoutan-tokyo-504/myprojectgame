using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
	public int maxHP;
	public int currentHP;
	private Text HPLabel;
    private Slider HPslider;

	void Start()
	{
        maxHP = 100;
		currentHP = maxHP;
		HPLabel = GameObject.Find("HPLabel").GetComponent<Text>();
        HPslider = GameObject.Find("HPbar").GetComponent<Slider>();
        HPLabel.text = "HP：" + currentHP + "/" + maxHP;
	}

    private void Update()
    {
        HPslider.value = currentHP;
        //HPslider.value -= 1;

    }

    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void GetCurrentHP(int amount)
    {
        //score += amount;
        currentHP = amount;
        HPLabel.text = "HP：" + currentHP + "/" + maxHP;
    }

    //public void HPreinforce(int amount)
    //{
    //    if (HPslider.value < HPslider.maxValue - 50)
    //    {
    //        HPslider.maxValue += amount;
    //        HPslider.value += 50;
    //    }
    //    else
    //    {
    //        HPslider.maxValue += amount;
    //        HPslider.value = HPslider.maxValue;
    //    }
    //}

}
