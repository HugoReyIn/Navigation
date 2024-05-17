using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillAction : MonoBehaviour
{
    public float attackRange = 2f;
    public int damageAmount = 1;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(AttackGhost());
        }
    }

    public IEnumerator AttackGhost()
    {
        animator.SetTrigger("Attack 02");

        yield return new WaitForSeconds(0.5f);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange))
        {
            GhostHealth ghostHealth = hit.transform.GetComponent<GhostHealth>();
            if (ghostHealth != null)
            {
                ghostHealth.Hit(damageAmount);
            }
        }
    }
}
