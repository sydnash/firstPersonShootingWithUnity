using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text scoreLabel;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private SettingPopup settingsPopup;
    private int _score;
	// Use this for initialization
	void Start () {
        settingsPopup.Close();
        _score = 0;
        scoreLabel.text = _score.ToString();
	}
	void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
	
    public void OnOpenSetting()
    {
        //Debug.Log("open setting");
        settingsPopup.Open();
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    public void onDrag()
    {
        Debug.Log("drag");
    }
    public void onMove()
    {
        Debug.Log("move");
    }
    public void onCancel()
    {
        Debug.Log("cancel");
    }
    public void onDrop()
    {
        Debug.Log("drop");
    }
    public void onEndDrag()
    {
        canvasGroup.blocksRaycasts = true;
        Debug.Log("end drag");
    }
    public void onBeginDrag()
    {
        canvasGroup.blocksRaycasts = false;
        Debug.Log("begin drag");
    }
}
