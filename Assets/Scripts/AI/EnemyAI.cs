using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	private WaypointController _waypointController;
	private NavMeshAgent _agent;

	private Queue<Waypoint> _waypointQueue;
	private Waypoint _currentWaypoint;

	private float _maxWalkDistance = 50f;


	// Use this for initialization
	void Start () {
		_waypointController = GameObject.Find("Waypoint Manager").GetComponent<WaypointController>();
		_agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Decesion Manger
		PatrolRandomly();
	}

	#region Future Strategy

	void PatrolWaypintsRandomly () {
		if (ReachDestinition()) {
			_currentWaypoint = _waypointController.getRandomWaypoint();
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}
	
	void PatrolWaypintsLinearly () {
		if (ReachDestinition()) {
			_currentWaypoint = _waypointController.getNextWaypoint(_currentWaypoint);
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}

	void PatrolWaypintsByPriority () {
		if (ReachDestinition()) {
			if (_waypointQueue == null || _waypointQueue.Count == 0) {
				_waypointQueue = _waypointController.getWaypointPriorityQueue();
			}
			
			_currentWaypoint = _waypointQueue.Dequeue();
			_agent.SetDestination(_currentWaypoint.transform.position);
		}
	}

	void PatrolRandomly() {
		if (ReachDestinition()) {
			Vector3 direction = Random.insideUnitSphere * _maxWalkDistance;
			direction += transform.position;
			
			NavMeshHit hit;
			NavMesh.SamplePosition(direction, out hit, Random.Range(0f, _maxWalkDistance), 1);
			Vector3 destination = hit.position;
			
			_agent.SetDestination(destination);
		}
	}

	private bool ReachDestinition() {
		return Vector3.Distance(transform.position, _agent.destination) < .5f;
	}

	#endregion
}
