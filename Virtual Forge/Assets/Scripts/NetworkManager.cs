using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;

    void Awake()
    {
	if(Instance)
	{
	    Destroy(gameObject);
	    return;
	}
	DontDestroyOnLoad(gameObject);
	Instance = this;
    }

    public override void OnEnable()
    {
	base.OnEnable();
	SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
	base.OnDisable();
	SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
	if (scene.buildIndex == 3) //Multiplayer Scene
	{
	    PhotonNetwork.Instantiate("PlayerManager", transform.position, transform.rotation);
	}
    }
}
