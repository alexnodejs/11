using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	private WaypointController _waypointController;
	private NavMeshAgent _agent;

	private Queue<Waypoint> _waypointQueue;
	private Waypoint _currentWaypoint;


	// Use this for initialization
	void Start () {
		_waypointController = GameObject.Find("Waypoint Manager").GetComponent<WaypointController>();
		_agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Decesion Manger
		PatrolByPriority();
	}

	#region Future Strategy

	void PatrolRandomly () {
		if (ReachDestinition()) {
			_currentWaypoint = _waypointController.getRandomWaypoint();
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}
	
	void PatrolLinearly () {
		if (ReachDestinition()) {
			_currentWaypoint = _waypointController.getNextWaypoint(_currentWaypoint);
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}

	void PatrolByPriority () {
		if (ReachDestinition()) {
			if (_waypointQueue == null || _waypointQueue.Count == 0) {
				_waypointQueue = _waypointController.getWaypointPriorityQueue();
			}
			
			_currentWaypoint = _waypointQueue.Dequeue();
			Debug.Log(_currentWaypoint.name);
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}

	private bool ReachDestinition() {
		return Vector3.Distance(transform.position, _agent.destination) < .5f;
	}

	#endregion
}
