using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRecognize : MonoBehaviour
{
    public int damage = 1;          //当たった部位毎のダメージ量
	public int sumdamage;    //継承させる用のダメージ
    private int parentdamage;
    float currenttime;
                             //   private int childdamage;  //子要素から引き継いだダメージ量
                             //   private int childnumber;  //子要素の数
    private float updatetime = 0.5f;

    void Start()
    {
        //childnumber = this.transform.childCount;
    }

    void Update()
    {
        //ParentObject.GetComponent<Transform>().position.x += sumdamage;
        //変数の初期化（継承させた後）一定時間ごとに行われる0
        currenttime += Time.deltaTime;
        //Debug.Log(currenttime);
        if (currenttime > updatetime)
        {
            sumdamage = 0;
            currenttime = 0;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "MachineGunBullet")
        {
            sumdamage += damage;
        }
    }


}
