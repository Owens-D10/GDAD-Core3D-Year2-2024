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
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Aim") && playerStatus.isPaused == false)
        {
            isAiming = true;
            Player.GetComponent<Animator>().Play("Aiming");

            
        }
        else if(Input.GetButtonUp("Aim"))
        {
            isAiming = false;
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
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
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
        gunshot.Play();
        Player.GetComponent<Animator>().Play("Shooting");
        ammoCount -= 1;
        yield return new WaitForSeconds(fireRate);
        Player.GetComponent<Animator>().Play("Aiming");
        isFiring = false;
    }

    IEnumerator GunClick()
    {
        gunClick.Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    public void AmmoGain()
    {
        ammoCount += ammoGain;
    }

    
}
