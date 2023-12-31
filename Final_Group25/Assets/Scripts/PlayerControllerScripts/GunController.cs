using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
	public float fireRate = 0.1f;
	public int clipSize = 30;
	public int reservedAmmoCapacity = 270;
	public float knockback;
	public float sendToSun;

	public GameObject Reticle;

	//Variables that change throughout code
	public bool canShoot;
	public int currentAmmoInClip;
	int ammoInReserve;

	//Muzzle Flash
	public Image muzzleFlashImage;
	public Sprite[] flashes;

	//Aiming
	public Vector3 normalLocalPosition;
	public Vector3 aimingLocalPosition;

	public float aimSmoothing = 10;

	//Weapon Sway
	[Header("Weapon Sway")]

	public float weaponSwayAmount = 10;

	//Weapon Recoil
	public bool randomizedRecoil;
	public Vector2 randomRecoilConstraints;
	
	//You only need to assign this if randomized recoil is off
	public Vector2 recoilPatterns;

	//Boop
	public float boopSpeed;
	public Transform boopSpawnPoint;
	public GameObject boopPrefab;



	private void Start()
	{
		currentAmmoInClip = clipSize;
		ammoInReserve = reservedAmmoCapacity;
		canShoot = true;
	}

	private void Update()
	{
		DetermineAim();

		DetermineRotation();

		if (Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(Boop());
		}
		
		if (Input.GetMouseButtonDown(0) && canShoot && currentAmmoInClip > 0)
		{
			canShoot = false;
			currentAmmoInClip--;
			StartCoroutine(ShootGun());
		}
		else if(Input.GetKeyDown(KeyCode.R) && currentAmmoInClip < clipSize && ammoInReserve >0)
		{
			int amountNeeded = clipSize - currentAmmoInClip;
			if (amountNeeded >= ammoInReserve)
			{
				currentAmmoInClip += ammoInReserve;
				ammoInReserve -= amountNeeded;
			}
			else
			{
				currentAmmoInClip = clipSize;
				ammoInReserve -= amountNeeded;
			}
		}
	}

	void DetermineRotation()
	{
		Vector2 mouseAxis = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		transform.localPosition += (Vector3)mouseAxis * weaponSwayAmount / 1000;
	}

	void DetermineAim()
	{
		Vector3 target = normalLocalPosition;
		if (Input.GetMouseButton(1)) target = aimingLocalPosition;

		Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

		transform.localPosition = desiredPosition;
	}

	void DetermineRecoil()
	{
		transform.localPosition -= Vector3.forward * 0.1f;

		if (randomizedRecoil)
		{
			float xRecoil = Random.Range(-randomRecoilConstraints.x, randomRecoilConstraints.x);
			float yRecoil = Random.Range(-randomRecoilConstraints.y, randomRecoilConstraints.y);

			Vector2 recoil = new Vector2(xRecoil, yRecoil);
		}
	}

	IEnumerator ShootGun()
	{
		DetermineRecoil();
		StartCoroutine(MuzzleFlash());
		yield return new WaitForSeconds(fireRate);
		canShoot = true;

		RayCastForEnemy();
	}

	IEnumerator MuzzleFlash()
	{
		muzzleFlashImage.sprite = flashes[Random.Range(0, flashes.Length)];
		muzzleFlashImage.color = Color.white;
		yield return new WaitForSeconds(0.05f);
		muzzleFlashImage.sprite = null;
		muzzleFlashImage.color = new Color(0, 0, 0, 0);
	}

	IEnumerator Boop()
	{
		DetermineRecoil();
		StartCoroutine(MuzzleFlash());
		yield return new WaitForSeconds(0.05f);
		canShoot = true;

        var bullet = Instantiate(boopPrefab, boopSpawnPoint.position, boopSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = boopSpawnPoint.forward * boopSpeed;
    }

    void RayCastForEnemy()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 1 << LayerMask.NameToLayer("Enemy")))
		{

			if (hit.collider.gameObject.tag == "Enemy")
			{
				hit.collider.GetComponent<SimpleEnemy>().TakeDamage(1);
			}

			try
			{
				//Debug.Log("Hit an Enemy");
				Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
				rb.constraints = RigidbodyConstraints.None;
				rb.AddForce(transform.parent.transform.forward * knockback);
			}
			catch
			{

			}
		}

		if (Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 1 << LayerMask.NameToLayer("Target")))
		{

			try
			{
				Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
				rb.constraints = RigidbodyConstraints.None;
				rb.AddForce(transform.parent.transform.forward * sendToSun);
			}
			catch
			{

			}
		}
	}


}
