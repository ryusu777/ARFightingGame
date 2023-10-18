using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource screamSound;
    public GameObject otherPlayer;
    void Start()
    {
        screamSound = GameObject.Find("ScreamSound").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMovingForward = animator.GetBool("isRunningForward");
        bool isMovingBackward = animator.GetBool("isRunningBackward");

        Vector3 movementDirection = new Vector3(0, 0, 0);
        bool isAttacking = IsAttacking();
        bool isStaggering = IsStaggering();

        if (isMovingForward && !isAttacking && !isStaggering)
        {
            movementDirection.z = otherPlayer.transform.position.z > transform.position.z ? 1 : -1;
        }

        if (isMovingBackward && !isAttacking && !isStaggering) 
        {
            movementDirection.z = otherPlayer.transform.position.z < transform.position.z ? 1 : -1;
        }

        transform.Translate(movementDirection * Time.deltaTime * 1.2f);
    }
    private bool IsAttacking(){
        return animator.GetCurrentAnimatorStateInfo(0).IsName("AttackingState");
    }
    private bool IsStaggering(){
        AnimatorStateInfo currState = animator.GetCurrentAnimatorStateInfo(0);
        return currState.IsName("Death") || currState.IsName("DeathReversed");
    }
    public void Attack() 
    {
        if (!IsStaggering()) {
            animator.Play("AttackingState");
            screamSound.Play();
        }
    }
    public void RunBackward() 
    {
        animator.SetBool("isRunningBackward", true);
    }
    public void StopRunBackward() 
    {
        animator.SetBool("isRunningBackward", false);
    }
    public void RunForward() 
    {
        animator.SetBool("isRunningForward", true);
    }
    public void StopRunForward() 
    {
        animator.SetBool("isRunningForward", false);
    }
}
