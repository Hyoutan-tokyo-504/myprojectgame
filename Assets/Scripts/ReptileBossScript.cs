using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReptileBossScript : MonoBehaviour
{
    float maxHP;
    float currentHP;
    public AudioClip walksound;
    public AudioClip attacksound;
    AudioSource audiosource;
    Animator animator;
    bool walk;
    bool attack;
    bool fallingback;
    private ScoreManager sm;
    public int scoreValue;
    public Slider slider;
    private BoundaryController boundaryhp;
    private EnemyManager lm4;
	// Start is called before the first frame update
	void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("Run", true);
        //slider = GameObject.Find("ReptileSlider").GetComponent<Slider>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		lm4 = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        boundaryhp = GameObject.Find("AttackBoundary").GetComponent<BoundaryController>();
        maxHP = slider.maxValue;
        currentHP = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHP);
        AnimatorControl();
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
                animator.SetBool("Dead", true);
                IEnumerator coroutine = DestroyMove();
                StartCoroutine(coroutine);
            }

            IEnumerator DestroyMove()
            {
                yield return new WaitForSeconds(1.0f);
                Destroy(this.gameObject);
                sm.AddScore(scoreValue);
                lm4.EnemyDead(4);
            }
        }
    }

    void AnimatorControl()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            this.transform.position += this.transform.forward * 15 * Time.deltaTime;
        }

        if (this.transform.position.z < 100)
        {
            boundaryhp.BoundaryHP -= 20;
            Destroy(this.gameObject);
        }

    }
}
