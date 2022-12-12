using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	private FSMSystem fsm;

	void Start()
	{
		InitFSM();
	}

	void InitFSM()
	{
		fsm = new FSMSystem();

		FSMState patrolState = new PatrolState(fsm);//巡逻
		patrolState.AddTransition(Transition.SeePlayer, StateID.Chase);

		FSMState chaseState = new ChaseState(fsm);//跟随玩家
		chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);
		chaseState.AddTransition(Transition.AttackPlayer, StateID.Attack);

		FSMState attackState = new AttackState(fsm);//攻击
		attackState.AddTransition(Transition.SeePlayer, StateID.Chase);
		attackState.AddTransition(Transition.LostPlayer, StateID.Patrol);

		fsm.AddState(patrolState);
		fsm.AddState(chaseState);
		fsm.AddState(attackState);
	}

	void Update()
	{
		fsm.Update(this.gameObject);
	}
}
