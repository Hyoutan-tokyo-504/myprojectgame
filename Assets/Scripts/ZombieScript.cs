using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    float maxHP;
    float currentHP;
    public GameObject ZombieAttack;
    //public AudioClip walksound;
    //public AudioClip attacksound;
    private float shotSpeed = 10;
    AudioSource audiosource;
    Animator animator;
    private float shotInterval;
    private ScoreManager sm;
    public int scoreValue;
    public Slider slider;
    private EnemyManager lm1;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("walk", true);
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        lm1 = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
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
        //AudioControl();
    }

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "MachineGunBullet")
        {
            Debug.Log(slider.value);
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
                lm1.EnemyDead(1);
            }
        }
    }

    void AnimatorControl()
    {
        if (this.transform.position.z < 100)
        {
            animator.SetBool("attack", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            this.transform.position += this.transform.forward * 3 * Time.deltaTime;
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
                GameObject bullet = (GameObject)Instantiate(ZombieAttack, this.transform.position - new Vector3(0, -1, 3), this.transform.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                Debug.Log(transform.forward);
                bulletRb.AddForce(transform.forward * shotSpeed);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                //Destroy(bullet, 3.0f);
            }
        }
    }

    //void AudioControl()
    //{
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack") == true)
    //    {
    //        audiosource.clip = attacksound;
    //        audiosource.Play();
    //    }
    //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk") == true)
    //    {
    //        audiosource.clip = walksound;
    //        audiosource.Play();
    //    }
    //}
}


