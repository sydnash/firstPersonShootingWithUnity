using UnityEngine;
using System.Collections;

public class WeatherController : MonoBehaviour {
    [SerializeField]
    private Material sky;
    [SerializeField]
    private Light sun;

    private float _fullIntensity;
    private float _cloundValue = 0f;
	// Use this for initialization
	void Start () {
        _fullIntensity = sun.intensity;
	}
	void Awake()
    {
        Messenger<float>.AddListener(GameEvent.WEATHER_UPDATED, SetOvercast);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.WEATHER_UPDATED, SetOvercast);
    }
	// Update is called once per frame
	void Update () {
        //SetOvercast(_cloundValue);
        //_cloundValue += 0.005f;
	}
    private void SetOvercast(float value) {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }

}
