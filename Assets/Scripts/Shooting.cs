using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}
    //　銃のステータススクリプト
    //private FPSWeaponStatus weaponStatus;
    //　銃口
    //public GameObject muzzle;
    //　弾の半径
    //private float muzzleRadius;
    //　一番近い敵
    //private GameObject nearEnemy;
    //ここから自作のスクリプト
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 30;
    public AudioClip BulletSound;
    public AudioClip ReloadSound;
    AudioSource audiosource;
    private float shotInterval;
    private bool fire;
    private bool reload;
    //private float distance;
    Color color;

    void Start()
    {
        //Debug.Log(muzzle);
        //　主人公のステータスを取得
        //weaponStatus = muzzle.GetComponentInParent<FPSWeaponStatus>();
        //　弾の半径を取得
        //muzzleRadius = muzzle.GetComponent<SphereCollider>().radius;
        audiosource = this.GetComponent<AudioSource>();
        fire = false;
    }

    void Update()
    {
        //Debug.DrawLine(muzzle.transform.position, muzzle.transform.position + muzzle.transform.forward * 1000, color = Color.yellow);
        Shoot();
        Reload();
        //Judge();
    }

    void Shoot()
    {
       
            if (Input.GetKey(KeyCode.Mouse0) || fire == true)
            {

                shotInterval += 1;

                if (shotInterval % 3 == 0 && shotCount > 0)
                {
                    shotCount -= 1;
                    audiosource.clip = BulletSound;
                    audiosource.Play();
                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                    bulletRb.AddForce(transform.forward * shotSpeed);
                    //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                    Destroy(bullet, 3.0f);
                }

            }
        
    }

    public void FireButtonDown()
    {
        fire = true;
    }

    public void FireButtonUp()
    {
        fire = false;
    }

    public void ReloadButtonDown()
    {
        reload = true;
    }

    public void ReloadButtonUp()
    {
        reload = false;
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || reload == true)
        {
            shotCount = 0;
            audiosource.clip = ReloadSound;
            audiosource.Play();
            IEnumerator coroutine = ReloadPause();
            StartCoroutine(coroutine);
        }
    } 
    IEnumerator ReloadPause()
    {         yield return new WaitForSeconds(1.0f);
        shotCount = 30;
    }



    

}
