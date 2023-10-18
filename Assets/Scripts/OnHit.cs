using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject OtherPlayer;
    Animator animator;
    string OtherPlayerNo;
    AudioSource staggeredSound;
    void Start()
    {
        staggeredSound = GameObject.Find("StaggeredSound").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (name == "PlayerOne") {
            OtherPlayerNo = "2";
            OtherPlayer = GameObject.Find("PlayerTwo");
        }
        if (name == "PlayerTwo") {
            OtherPlayerNo = "1";
            OtherPlayer = GameObject.Find("PlayerOne");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
	{
        bool isOtherAttacking = OtherPlayer
                .GetComponent<Animator>()
                .GetCurrentAnimatorStateInfo(0)
                .IsName("AttackingState");

        bool isMeStaggered =
            animator.GetCurrentAnimatorStateInfo(0).IsName("Death") || 
            animator.GetCurrentAnimatorStateInfo(0).IsName("DeathReversed");

        if (other.gameObject.CompareTag("PlayerAxe" + OtherPlayerNo) 
            && isOtherAttacking
            && !isMeStaggered)
		{
            staggeredSound.Play();
            animator.Play("Death");
		}
	}
}
