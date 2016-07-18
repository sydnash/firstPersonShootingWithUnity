using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class ImageManager : MonoBehaviour , IGameManager {
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    private Texture2D _webImages;
	// Use this for initialization
	void Start () {
	
	}
    public void Startup(NetworkService service)
    {
        Debug.Log("Images manager starting...");

        _network = service;
        status = ManagerStatus.Started;
    }
	public void GetWebImage(Action<Texture2D> callback)
    {
        if (_webImages == null)
        {
            //StartCoroutine(_network.DownloadImage(callback));
            StartCoroutine(_network.DownloadImage((Texture2D image) =>
            {
                _webImages = image;
                callback(_webImages);
            }));
        } else
        {
            callback(_webImages);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}

}
