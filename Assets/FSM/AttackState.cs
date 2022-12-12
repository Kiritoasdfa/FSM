using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState
{
    public Transform playerTransform;
    public AttackState(FSMSystem fsm) : base(fsm)
    {
        stateID = StateID.Attack;
        playerTransform = GameObject.Find("Player").transform;
    }
    public override void Act(GameObject npc)
    {
        npc.transform.LookAt(playerTransform.position);
        Debug.Log("攻击");
    }

    public override void Reason(GameObject npc)
    {
        //if (Vector3.Distance(playerTransform.position, npc.transform.position) < 5)
        //{
        //    fsm.PerformTransition(Transition.SeePlayer);
        //}
        if (Vector3.Distance(playerTransform.position, npc.transform.position) > 2)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }
}
