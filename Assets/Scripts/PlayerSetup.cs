using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] componentsToDisable;

    [SerializeField]
    private string remoteLayerName = "RemotePlayer";
    private Camera sceneCamera;


    private void Start() {
        for (int i = 0; i < componentsToDisable.Length; i++) {
            componentsToDisable[i].enabled = isLocalPlayer;
        }

        if (isLocalPlayer) {
            sceneCamera = Camera.main;

            if (sceneCamera != null) {
                sceneCamera.gameObject.SetActive(false);
            }
        }
        else {
            DisableComponents();
            AssignRemoteLayer();
        }
        RegistarPlayer();
    }

    private void RegistarPlayer() {
        string id = "Player" + GetComponent<NetworkIdentity>().netId;
        transform.name = id;
    }

    private void DisableComponents() {

    }

    private void AssignRemoteLayer() {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void OnDisable() {
        if (sceneCamera != null) {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
