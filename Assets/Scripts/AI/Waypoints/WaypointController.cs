using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointController : MonoBehaviour {

	public List<Waypoint> Waypoints;

	/// <summary>
	/// Gets the random waypoint.
	/// </summary>
	/// <returns>The random waypoint.</returns>
	public Waypoint getRandomWaypoint() {
		int rnd = Random.Range(0,(Waypoints.Count - 1));
		return Waypoints[rnd];
	}

	/// <summary>
	/// Gets the next waypoint.
	/// </summary>
	/// <returns>The next waypoint.</returns>
	/// <param name="excludedWaypoint">Excluded waypoint.</param>
	public Waypoint getNextWaypoint(Waypoint excludedWaypoint) {
		int position = Waypoints.IndexOf(excludedWaypoint);

		return Waypoints[position == -1 ? 0 : (position + 1) % Waypoints.Count];
	}

	/// <summary>
	/// Gets the waypoint priority queue.
	/// </summary>
	/// <returns>The waypoint priority queue.</returns>
	public Queue<Waypoint> getWaypointPriorityQueue() {
		List<Waypoint> sortedWaypoints = new List<Waypoint>(Waypoints);

		sortedWaypoints.Sort(delegate(Waypoint i1, Waypoint i2) { 
			return i2.Priority.CompareTo(i1.Priority);
		});

		Debug.Log("=====>");

		return new Queue<Waypoint>(sortedWaypoints);
	}
}
