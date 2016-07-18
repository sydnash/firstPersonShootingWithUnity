using UnityEngine;
using System.Collections;

public class WebLoadingBillboard : MonoBehaviour {
        public Camera m_Camera;
    public void Operate()
    {
        Managers.image.GetWebImage(OnWebImage);
    }
    private void OnWebImage(Texture2D image)
    {
        GetComponent<Renderer>().material.mainTexture = image;
    }
	// Use this for initialization
	void Start () {
        Operate();
        m_Camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                m_Camera.transform.rotation * Vector3.up);
    }
}
