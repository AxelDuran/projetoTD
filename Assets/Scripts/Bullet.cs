using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;


    [SerializeField] private float speed = 70f;
    [SerializeField] private GameObject hitBulletEffect;
    [SerializeField] private Vector3 targetOffset; // corrige a direção da bala que segue o pivo dos objetos

    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate((dir.normalized + targetOffset) * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Debug.Log("Alguma coisa");
        GameObject effects =  Instantiate(hitBulletEffect, transform.position + targetOffset, transform.rotation);
        Destroy(effects, 1f );
        target.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
