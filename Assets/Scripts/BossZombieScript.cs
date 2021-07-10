using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossZombieScript : MonoBehaviour
{
    float maxHP;
    float currentHP;
    public GameObject BossZombieAttack;
    public AudioClip walksound;
    public AudioClip attacksound;
    private float shotSpeed = 10;
    AudioSource audiosource;
    Animator animator;
    bool walk;
    bool attack;
    bool fallingback;
    private float shotInterval;
    private ScoreManager sm;
    private EnemyManager lm1;
    public int scoreValue;
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("walk", true);
        //currentHP = maxHP;
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        lm1 = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        //slider = GameObject.Find("BossZombieSlider").GetComponent<Slider>();
        maxHP = slider.maxValue;
        currentHP = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHP);
        AnimatorControl();
        Attack();
    }

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "MachineGunBullet")
        {
            currentHP -= 1;
            slider.value = currentHP;
            if (currentHP < 0.5)
            {
                animator.SetBool("falling back", true);
                IEnumerator coroutine = DestroyMove();
                StartCoroutine(coroutine);
            }
            IEnumerator DestroyMove()
            {
                yield return new WaitForSeconds(1.0f);
                Destroy(this.gameObject);
                sm.AddScore(scoreValue);
                lm1.EnemyDead(2);
            }
        }
    }

    void AnimatorControl()
    {
        if (this.transform.position.z < 100)
        {
            animator.SetBool("attack", true);
        }
    }

    void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack") == true)
        {
            shotInterval += 1;

            if (shotInterval % 20 == 0)
            {
                //audiosource.clip = BulletSound;
                //audiosource.Play();
                GameObject bullet = (GameObject)Instantiate(BossZombieAttack, this.transform.position - new Vector3(0, -1, 3), this.transform.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                Debug.Log(transform.forward);
                bulletRb.AddForce(transform.forward * shotSpeed);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                //Destroy(bullet, 3.0f);
            }
        }
    }
}
