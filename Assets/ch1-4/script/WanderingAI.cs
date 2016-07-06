using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float rotateRange = 110;
    public bool isDie = false;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public const float baseSpeed = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	public void setDie()
    {
        isDie = true;
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnSpeedChanged(float sp)
    {
        speed = baseSpeed * sp;
    }
	// Update is called once per frame
	void Update () {
        if (isDie)
        {
            return;
        }
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(transform.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-rotateRange, rotateRange);
                transform.Rotate(0, angle, 0);
            }
        }
	}
}
