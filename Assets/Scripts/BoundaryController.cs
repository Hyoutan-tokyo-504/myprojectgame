using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoundaryController : MonoBehaviour
{
    public int BoundaryHP;
    private HPManager HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("HPManager").GetComponent<HPManager>();
        BoundaryHP = HP.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HP.GetCurrentHP(BoundaryHP);
        if(BoundaryHP < 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void HPreinforce(int amount)
    {
        if (BoundaryHP < HP.maxHP - 50)
        {
            HP.maxHP += amount;
            BoundaryHP += 50;
        }
        else
        {
            HP.maxHP += amount;
            BoundaryHP = HP.maxHP;
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ZombieAttack")
        {
            BoundaryHP -= 3;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BossZombieAttack")
        {
            BoundaryHP -= 5;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Reptile")
        {
            BoundaryHP -= 5;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "ReptileBoss")
        {
            Debug.Log(col.gameObject.tag);
            BoundaryHP -= 15;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BugAttack")
        {
            BoundaryHP -= 3;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BomberExplode")
        {
            BoundaryHP -= 10;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BugBossAttack")
        {
            BoundaryHP -= 5;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BugBossExplode")
        {
            BoundaryHP -= 20;
            Destroy(col.gameObject);
        }
    }
}
