using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSampleScript : MonoBehaviour
{
    public int zombiecount;
    public int leftzombiecount;
    public int bosszombiecount;
    public int leftbosszombiecount;
    private int instantiatedzombiecount;
    private int instantiatedbosszombiecount;
    private float intervaltime;
    public GameObject zombie;
    public GameObject bosszombie;
    // Start is called before the first frame update
    void Start()
    {
        leftzombiecount = zombiecount;
        leftbosszombiecount = bosszombiecount;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyInstantiate();
        LevelClear();
    }

    public void EnemyDead(int kind)
    {
        //１は普通のゾンビ、２はボスゾンビ
        if (kind == 1)
        {
            leftzombiecount -= 1;
        }
        if (kind == 2)
        {
            leftbosszombiecount -= 1;
        }
    }

    void EnemyInstantiate()
    {
        intervaltime += Time.deltaTime;
        if (intervaltime > 5.0f)
        {
            intervaltime = 0.0f;
            if (instantiatedzombiecount < 19.5)
            {
                Instantiate(zombie, new Vector3(490, 4, 240) + new Vector3(1, 0, 0) * Random.Range(-10.0f, 10.0f), Quaternion.Euler(0, 180, 0));
                instantiatedzombiecount += 1;
            }

            if (instantiatedzombiecount > 19.5 && instantiatedbosszombiecount < 0.5)
            {
                Instantiate(bosszombie, new Vector3(490, 4, 240), Quaternion.Euler(0, 180, 0));
                instantiatedbosszombiecount += 1;
            }

        }
    }
    void LevelClear()
    {
        if (leftbosszombiecount < 0.5 && leftzombiecount < 0.5)
        {
            Debug.Log("clear");
        }
    }
}
