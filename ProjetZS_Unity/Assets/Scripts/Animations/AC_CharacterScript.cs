using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_CharacterScript : MonoBehaviour
{
    public CharacterController playerController;
    public Animator animator;

    public float runSpeed = 6;
    public bool didAttack = false;

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsAttacking", true);
            print("Attack");
            didAttack = true;
        }

        else if (verticalMove != 0)
        {
            animator.SetBool("IsWalking", true);
            Move(verticalMove);
        }
        else
        {
            if (didAttack == true)
            {
                animator.SetBool("IsAttacking", false);
            }
            animator.SetBool("IsWalking", false);
        }
        
    }

    private void Move(float mv)
    {
        Vector3 move = transform.forward * mv;
        playerController.Move(runSpeed * Time.deltaTime * move);
    }
}
