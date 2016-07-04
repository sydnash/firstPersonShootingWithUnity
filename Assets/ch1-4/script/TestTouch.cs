using UnityEngine;
using System.Collections;

public class TestTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        //Application.LoadLevel("SomeLevel");
        Debug.Log("mouse down");
    }
}
