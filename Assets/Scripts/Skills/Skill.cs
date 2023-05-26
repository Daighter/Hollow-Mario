using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected GameObject effectPrefab;
    protected Rigidbody rb;
    protected int player_ap;
    protected int skill_ap;
    protected float runTime = 0.1f;

    protected void Update()
    {
        if (runTime < 0)
            Destroy(gameObject);

        runTime -= Time.deltaTime;
    }

    protected void OnTriggerEnter(Collider other)
    {
        IHitable target = other.gameObject.GetComponent<IHitable>();
        if (target != null)
            target.TakeDamage(skill_ap);
    }
}
