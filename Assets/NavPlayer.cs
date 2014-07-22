using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NavPlayer : MonoBehaviour {

	NavMeshAgent	agent;

	public GameObject		prefabIndicator;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		MouseTarget();
	}

	void MouseTarget()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray rayGround = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitGround;
			var groundLayermask = 1 << 8;
			
			if(Physics.Raycast (rayGround, out hitGround, Mathf.Infinity, groundLayermask))
			{
				agent.SetDestination(hitGround.point);
				if(prefabIndicator) {
					GameObject instance = (GameObject) GameObject.Instantiate(prefabIndicator, hitGround.point, Quaternion.identity);
					Destroy(instance, 1f);
				}
			}
		}
	}

	void OnGUI()
	{
		GUI.Box (new Rect(0, 0, 128, 32), "Navigatoin Tutorial");
		string selectedUnits = string.Empty;
	}
}
