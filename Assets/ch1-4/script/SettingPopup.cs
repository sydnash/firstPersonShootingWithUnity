using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SettingPopup : MonoBehaviour {

    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private InputField nameInput;
	// Use this for initialization
	void Start () {
        speedSlider.value = PlayerPrefs.GetFloat("speed");
        nameInput.text = PlayerPrefs.GetString("name");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnSubmitName(string name)
    {
        Debug.Log("name: " + name);
        PlayerPrefs.SetString("name", name);
    }
    public void OnSpeedValue(float speed)
    {
        Debug.Log("Speed: " + speed);
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
