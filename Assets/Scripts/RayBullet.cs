using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBullet : MonoBehaviour
{

    private LineRenderer myLineRender;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    LayerMask hitLayer;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float shootRange;

    private void Awake()
    {
        myLineRender = GetComponent<LineRenderer>();
    }
    void Start()
    {
        RaycastHit hit;
        myLineRender.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange, hitLayer))
        {

            myLineRender.SetPosition(1, hit.point);

            if (hit.transform.GetComponent<PlayerController>())
            {
                PlayerHealth playerHealthScript = hit.transform.GetComponent<PlayerHealth>();
                playerHealthScript.TakeDamage(damage);
            }
        }
        else
        {
            myLineRender.SetPosition(1, transform.position + (transform.forward * shootRange));
        }

        StartCoroutine(DestroyLifeTime());
    }

    public IEnumerator DestroyLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
