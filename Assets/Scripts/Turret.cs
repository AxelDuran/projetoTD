using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
   [SerializeField]private float range = 15f;
   [SerializeField]private float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Settup Fields")]
   [SerializeField] private string enemyTag = "Enemy";
   [SerializeField] private Transform baseToRotate;
   [SerializeField] private float turnSpeed = 10f;
  [SerializeField] private GameObject bulletPrefab;
   [SerializeField] private Transform shooterPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortDistance <= range)
         {
            target = nearestEnemy.transform;
         }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(baseToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        baseToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //shoot in enemy

        if(fireCountDown <= 0f)
        {
            Shoot();

            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bulletGO =  Instantiate(bulletPrefab, shooterPoint.position, shooterPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
