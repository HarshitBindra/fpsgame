
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10000f;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject HitEffect;
    public float Firerate=8f;

    public float NextTimeToFire = 0f;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
          {
            NextTimeToFire = Time.time + 1f / Firerate;
            Shoot();
            
                FindObjectOfType<AudioManager>().Play("shootar");
            
        }
    }
    void Shoot()

    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position,fpscam.transform.forward,out hit,range))
        {
            
            Target target = hit.transform.GetComponent<Target>();
            if(target!=null)
            {
                Debug.Log(hit.transform.name);
                target.TakeDamage(damage);
            }
            GameObject impactGO =Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
