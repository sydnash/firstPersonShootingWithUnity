using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public float speed = 10;
    public int damage = 1;
	// Use this for initialization
	void Start () {
	}
	
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            //Debug.Log("hit player");
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
