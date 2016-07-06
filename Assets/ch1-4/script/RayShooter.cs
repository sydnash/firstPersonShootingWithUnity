using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {
    private Camera _camera;
	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
	}
	
    void OnGUI()
    {
        int size = 12;
        float posx = _camera.pixelWidth * 0.5f - size / 4;
        float posy = _camera.pixelHeight * 0.5f - size / 2;
        GUI.Label(new Rect(posx, posy, size, size), "*");
    }
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth * 0.5f, _camera.pixelHeight * 0.5f, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Hit " + hit.point);
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    //Debug.Log("target hit");
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                } else
                {
                    StartCoroutine(ShpereIndicator(hit.point));
                }
            }
        }
	}
    private IEnumerator ShpereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
