using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10000f;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject HitEffect;
    

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
            
            
                FindObjectOfType<AudioManager>().Play("shootpistol");
            
        }
    }
    void Shoot()

    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log(hit.transform.name);
                target.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}