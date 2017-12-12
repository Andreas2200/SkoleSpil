using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public int bulletSpeed = 10;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, 2f);
    }
}
