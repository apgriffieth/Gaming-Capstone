using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createRoomNameInputField;
    [SerializeField] TMP_InputField joinRoomNameInputField;
    [SerializeField] TMP_Text errorText;

    // Start is called before the first frame update
    void Awake()
    {
	Debug.Log("Connecting to Master...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
	Debug.Log("Connected to Master");
	base.OnConnectedToMaster();
    }

    public void CreateRoom()
    {
	errorText.text = "";
	if (string.IsNullOrEmpty(createRoomNameInputField.text))
	{
	    errorText.text = "Room Creation Failed: Room Name Cannot Be Empty";
	    return;
	}

	RoomOptions roomOptions = new RoomOptions();
	roomOptions.MaxPlayers = 2;
	roomOptions.IsVisible = true;
	roomOptions.IsOpen = true;
	PhotonNetwork.CreateRoom(createRoomNameInputField.text, roomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
	errorText.text = "";
	if (string.IsNullOrEmpty(joinRoomNameInputField.text))
	{
	    errorText.text = "Room Join Failed: Room Name Cannot Be Empty";
	    return;
	}

	PhotonNetwork.JoinRoom(joinRoomNameInputField.text);
    }

    public override void OnJoinedRoom()
    {
	base.OnJoinedRoom();
	PhotonNetwork.LoadLevel(3);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
	errorText.text = "Room Creation Failed: " + message;
	base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
	errorText.text = "Room Join Failed: " + message;
	base.OnJoinRoomFailed(returnCode, message);
    }
}
