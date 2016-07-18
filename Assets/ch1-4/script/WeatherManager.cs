using UnityEngine;
using System;
using System.Xml;
using System.Collections.Generic;
using MiniJSON;

public class WeatherManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    public float cloudValue { get; private set; }
    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");

        _network = service;
        StartCoroutine(_network.GetWeatherJSON(OnJSONDataLoaded));

        status = ManagerStatus.Ininting;
    }
    public void OnXMLDataLoaded(string data)
    {
        Debug.Log(data);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;

        Debug.Log("Value: " + cloudValue);

        Messenger<float>.Broadcast(GameEvent.WEATHER_UPDATED, cloudValue);


        status = ManagerStatus.Started;
    }
    public void OnJSONDataLoaded(string data)
    {
        Dictionary<string, object> dict;
        dict = Json.Deserialize(data) as Dictionary<string, object>;

        Dictionary<string, object> clouds = (Dictionary<string, object>)dict["clouds"];
        cloudValue = (long)clouds["all"] / 100f;
        Debug.Log("Value: " + cloudValue);

        Messenger<float>.Broadcast(GameEvent.WEATHER_UPDATED, cloudValue);

        status = ManagerStatus.Started;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
