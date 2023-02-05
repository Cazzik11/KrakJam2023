using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform MuzzleTransform;
    [Range(0f, 1f)]
    public float CoolDown = 0.2f;

    public GameObject MuzzleFlash;
    public int FramesToFlash = 1;

    float _nextFireTime = 0f;

    bool _isFlashing = false;

    void Start()
    {
        MuzzleFlash.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _nextFireTime = Time.time + CoolDown;
            Shoot();
        }
    }

    void Shoot ()
    {
       Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       if (!_isFlashing)
       {
            StartCoroutine(DoFlash());
       }

    }

    IEnumerator DoFlash()
    {
        MuzzleFlash.SetActive(true);
        var framesFlashed = 0;
        _isFlashing = true;

        while(framesFlashed <= FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }

        MuzzleFlash.SetActive(false);
        _isFlashing = false;
    }
}

