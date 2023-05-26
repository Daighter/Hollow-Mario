using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Rigidbody rb;
    protected int player_ap;
    protected int skill_ap;
    [SerializeField] protected int skillPersent = 2;
    protected float runTime = 0.1f;

    protected void Start()
    {
        skill_ap = player_ap * skillPersent;
    }

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

    public void GetPlayerAp(int player_ap)
    {
        this.player_ap = player_ap;
    }
}
