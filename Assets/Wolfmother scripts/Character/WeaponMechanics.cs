using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponMechanics : MonoBehaviour
{
    public static bool isAiming = false;
    public GameObject Player;
    public Animator playerAnimator;
    public float horizontalMove;
    public AudioSource gunshot;
    public bool isFiring;
    public float fireRate = 0.5f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int ammoCount = 10;
    public AudioSource gunClick;
    public int ammoGain = 5;
    public PlayerStatus playerStatus;
    public float range;
    public int damage = 1;
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Aim") && playerStatus.isPaused == false)
        {
            isAiming = true;
            GetComponent<Animator>().SetBool("isAiming", true);

            
        }
        else if(Input.GetButtonUp("Aim"))
        {
            isAiming = false;
            GetComponent<Animator>().SetBool("isAiming", false);
        }

        if (isAiming == true)
        {   // Rotating while aiming
            if (Input.GetButton("Horizontal"))
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                Player.transform.Rotate(0, horizontalMove, 0);
            }

            // Firing Gun
            if (Input.GetButton("ActionButton") && isFiring == false && ammoCount > 0)
            {
                isFiring = true;
                Shoot();
                
                StartCoroutine(FiringWeapon());
            }
            if(Input.GetButton("ActionButton") &&isFiring == false && ammoCount == 0)
            {
                isFiring = true;
                StartCoroutine(GunClick());
            }


        }


    }

    IEnumerator FiringWeapon()
    {
        gunshot.pitch = UnityEngine.Random.Range(1f, 1.5f);
        gunshot.Play();
        GetComponent<Animator>().SetTrigger("Shoot");
        ammoCount -= 1;
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    IEnumerator GunClick()
    {
        gunClick.pitch = UnityEngine.Random.Range(1f, 1.5f);
        gunClick.Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    public void AmmoGain()
    {
        ammoCount += ammoGain;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.forward, out hit, range))
        {
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy  != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        
    }

    
}
