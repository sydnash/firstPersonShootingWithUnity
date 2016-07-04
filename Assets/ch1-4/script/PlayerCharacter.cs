using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
    public int health = 5;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }
}
