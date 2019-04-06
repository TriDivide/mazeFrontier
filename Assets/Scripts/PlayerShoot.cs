using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    public PlayerWeapon weapon;


    private void Start() {
        if (cam == null) {
            Debug.LogError("PlayerShoot No Camera Found");
            this.enabled = false;
        }
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    [Client]
    private void Shoot() {
        RaycastHit raycastHit;
        var origin = cam.transform;

        if (Physics.Raycast(origin.position, origin.forward, out raycastHit, weapon.range, mask)) {
            if (raycastHit.collider.tag == "Player") {
                CmdPlayerShot(raycastHit.collider.name);
            }
        }
    }

    [Command]
    private void CmdPlayerShot(string id) {
        Debug.Log(id + " has been hit");
    }
}

