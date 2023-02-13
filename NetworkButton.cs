using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkButton : MonoBehaviour
{
   
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(150, 200, 300, 300));

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {

            if (GUILayout.Button("Join Game as Client")) NetworkManager.Singleton.StartClient();

            if (GUILayout.Button("Host Game")) NetworkManager.Singleton.StartHost();

            if (GUILayout.Button("Start Server")) NetworkManager.Singleton.StartServer();
        }
        GUILayout.EndArea();
    }
}