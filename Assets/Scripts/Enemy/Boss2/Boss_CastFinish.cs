using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_CastFinish : StateMachineBehaviour
{
    public Boss2 boss2;
    public SpellDamage spell;
    public GameObject Spell;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2 = animator.GetComponent<Boss2>();
        Spell = GameObject.Find("Player");
        spell = animator.GetComponent<SpellDamage>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        int nub = UnityEngine.Random.Range(3, 5);
        if (nub == 3)
            boss2.state = Boss2State.Walk;
        else if (nub == 4)
            boss2.state = Boss2State.Walk2;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
