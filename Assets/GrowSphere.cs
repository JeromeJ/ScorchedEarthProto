using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSphere : MonoBehaviour {

    public static GrowSphere _instance;

    public float _scalePercent;
    public float _min;
    public float _max;



    // Use this for initialization
    void Awake () {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
