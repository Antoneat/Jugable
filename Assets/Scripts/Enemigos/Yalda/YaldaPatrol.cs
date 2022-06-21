using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaldaPatrol : MonoBehaviour
{

	

	public UnityEngine.AI.NavMeshAgent agent;

	public int destPoint = 0;
	public Transform goal;

	public float playerDistance;
	public float awareAI;
	public float atkRange;
	public Yaldabaoth y;

	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		//agent.autoBraking = false;

		goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent.SetDestination(goal.position);
	}

	void Update()
	{
		playerDistance = Vector3.Distance(transform.position, goal.position);

		if (playerDistance <= awareAI)
		{
			LookAtPlayer();
			Debug.Log("Seen");
			Chase();
			agent.isStopped = false;
		}
		else if (playerDistance > awareAI)
		{
			LookAtPlayer();
			agent.isStopped = true;
		}


		if (playerDistance <= atkRange)
		{
			y.ChooseAtk3();
			agent.isStopped = false;
		}
		else if (playerDistance > atkRange)
		{
			LookAtPlayer();
			agent.isStopped = false;

		}
	}

	void LookAtPlayer()
	{
		transform.LookAt(goal);
	}



	public void Chase()
	{
		agent.stoppingDistance = 3;
		agent.SetDestination(goal.position);

		//transform.Translate(Vector3.forward * Speed * Time.deltaTime);

		if (agent.remainingDistance > agent.stoppingDistance)
		{
			agent.isStopped = false;

		}
		else if (agent.remainingDistance < agent.stoppingDistance)
		{
			agent.isStopped = true;
		}

	}


}
