using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlayerToGrowSphere : MonoBehaviour {

    private GrowSphere gs;

	// Use this for initialization
	void Start () {
		if(gs == null)
        {
            gs = GrowSphere._instance;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
