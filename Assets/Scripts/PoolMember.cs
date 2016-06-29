using UnityEngine;  
using System.Collections;  
public class PoolMember : MonoBehaviour {  
	public Pool pool;  

	void OnDisable () {  
		pool.nextThing = gameObject;  
	}  
}
