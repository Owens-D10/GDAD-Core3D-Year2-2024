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
    public float fireRate = 1f;
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
    public bool canShoot = true;

    [SerializeField] LayerMask target; // Layer mask for what can take damage from gun
    [SerializeField] LayerMask obstruction; // Layer mask for what obstructs gub
    // Update is called once per frame 
    void Update()
    {

        
        if (Input.GetButtonDown("Aim") && playerStatus.isPaused == false) // starts aiming
        {
            isAiming = true;
            GetComponent<Animator>().SetBool("isAiming", true);

            
        }
        else if(Input.GetButtonUp("Aim")) // stops aiming
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
                
                FiringWeapon();
            }
            
            if(Input.GetButton("ActionButton") &&isFiring == false && ammoCount == 0)
            {
                isFiring = true;
                StartCoroutine(GunClick());
            }
            


        }


    }

    // 
    void FiringWeapon() // plays gunchot sound effect and shooting animation. Also takes away from the ammo count
    {
        gunshot.pitch = UnityEngine.Random.Range(0.5f, 1f);
        gunshot.Play();
        GetComponent<Animator>().SetTrigger("Shoot");
        ammoCount -= 1;
        
    }

    // Plays cliking sound effect to indicate no ammo
    IEnumerator GunClick() // plays gun click sound effect and starts gun cooldown
    {
        gunClick.pitch = UnityEngine.Random.Range(1f, 1.5f);
        gunClick.Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
        
    }


    public void AmmoGain() // adds to ammo count when ammo boxes are collected
    {
        ammoCount += ammoGain;
    }

    // Shoot Raycast Method
    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, range, target)) // Hits and deals damage to enemies
        {
            Debug.Log("Hit Enemy");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            hit.collider.gameObject.GetComponent<Enemy>()?.TakeDamage(damage);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, obstruction)) // Hits obstructions such as walls
        {
            Debug.Log("Hit Nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        
    }

    void FinishedFiring() // Method is called by shooting animation for the gun's cooldown
    {
        isFiring = false;
    }

    
}
