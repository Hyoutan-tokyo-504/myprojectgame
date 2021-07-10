using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanScript : MonoBehaviour
{
    float maxHP = 20;
    float currentHP;
    public AudioClip walksound;
    public AudioClip attacksound;
    AudioSource audiosource;
    Animator animator;
    bool walk;
    bool attack1;
    bool attack2;
    bool attack3;
    bool fallingback;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("Walk 0", true);
        currentHP = maxHP;
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
            Debug.Log(currentHP);
            currentHP -= 1;
        }
    }

    void AnimatorControl()
    {
        if (currentHP < 0)
        {
            animator.SetBool("Death", true);
            IEnumerator coroutine = DestroyMove();
            StartCoroutine(coroutine);
        }

        IEnumerator DestroyMove()
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(this.gameObject);
        }
    }
}
