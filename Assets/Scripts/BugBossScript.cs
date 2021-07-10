using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugBossScript : MonoBehaviour
{
    float maxHP;
    float currentHP;
    int attackcount;
    public GameObject BugBossAttack;
    public GameObject BugBossExplode;
    public AudioClip attacksound;
    private float shotSpeed = 100;
    AudioSource audiosource;
    Animator animator;
    private float shotInterval;
    private ScoreManager sm;
    public int scoreValue;
    public Slider slider;
    private EnemyManager lm6;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        lm6 = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        //slider = GameObject.Find("ZombieSlider").GetComponent<Slider>();
        maxHP = slider.maxValue;
        currentHP = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHP);
        AnimatorControl();
        Attack();
        AudioControl();
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
                animator.SetBool("death", true);
                IEnumerator coroutine = DestroyMove();
                StartCoroutine(coroutine);
            }
            IEnumerator DestroyMove()
            {
                yield return new WaitForSeconds(1.0f);
                Destroy(this.gameObject);
                sm.AddScore(scoreValue);
                lm6.EnemyDead(6);
            }
        }
    }

    void AnimatorControl()
    {
        if (this.transform.position.z < 100)
        {
            animator.SetBool("attack1", true);
        }
    }

    void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") == true)
        {
            shotInterval += 1;

            if (shotInterval % 30 == 0)
            {
                //audiosource.clip = BulletSound;
                //audiosource.Play();
                GameObject bullet = (GameObject)Instantiate(BugBossAttack, this.transform.position - new Vector3(0, -1, 3), this.transform.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
                attackcount += 1;
                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                //Destroy(bullet, 3.0f);

            }
        }
        if (attackcount == 5)
        {
            animator.SetBool("explode", true);
            IEnumerator coroutine = ExplodeDestroyMove();
            StartCoroutine(coroutine);
            IEnumerator ExplodeDestroyMove()
            {
                yield return new WaitForSeconds(1.0f);
                GameObject explodebullet = (GameObject)Instantiate(BugBossExplode, this.transform.position - new Vector3(0, -1, 3), this.transform.rotation);
                Rigidbody explodebulletRb = explodebullet.GetComponent<Rigidbody>();
                explodebulletRb.AddForce(transform.forward * shotSpeed);
                Destroy(this.gameObject);
                sm.AddScore(scoreValue);
            }

        }
    }

    void AudioControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") == true)
        {
            audiosource.clip = attacksound;
            audiosource.Play();
        }
    }
}
