using UnityEngine;
using System.Collections;

//this forces the playercontroller to be bound to the player object
[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))] 
public class Player : LivingEntity {

    public float moveSpeed = 5;

    //Gameobject References
    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        controller = GetComponent<PlayerController> ();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        //Move Input
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //Look Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        //Weapon Input
        if (Input.GetMouseButton(0)) {
            gunController.Shoot();
        }
	}
}
