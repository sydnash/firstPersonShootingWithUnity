using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    private float speed = 3.0f;
    public float basicSpeed = 3.0f;
	// Use this for initialization
	void Start () {
	}
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, onSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, onSpeedChanged);
    }
    void onSpeedChanged(float sp)
    {
        speed = basicSpeed * sp;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy.GetComponent<WanderingAI>().speed = 6;
        }
	}
}
