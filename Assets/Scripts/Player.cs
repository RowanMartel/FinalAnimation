using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //ref: Code like Me https://www.youtube.com/channel/UCU9YE0hMnTt6TozuyVKicHA

    private float forwardInput;
    private float rightInput;

    private BoxCollider leg;

    public CameraController cameraController;
    public PlayerMovement playerMovement;
    PlayerAnimationController playerAnimation;

    private Vector3 velocity;

    [HideInInspector]
    public bool kicking;

    public Image RunToggleUI;

    public Text velocityText;

    private void Start()
    {
        kicking = false;
        playerAnimation = FindObjectOfType<PlayerAnimationController>();
        leg = transform.GetChild(2).GetChild(2).GetComponent<BoxCollider>();
    }

    void Update()
    {
        velocityText.text = getVelocity().ToString("#.00");
        if (kicking) leg.enabled = true;
        else leg.enabled = false;
    }

    public void AddMovementInput(float forward, float right)    // update movement inputs
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 camRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;
        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        playerMovement.Velocity = translation;
    }

    public float getVelocity()
    {
        return playerMovement.Velocity.magnitude;
    }

    public void ToggleRun()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Running)
        {
            playerMovement.SetMovementMode(MovementMode.Running);
            RunToggleUI.GetComponent<Image>().color = Color.green;
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
            RunToggleUI.GetComponent<Image>().color = Color.red;
        }
    }

    public void Kick()
    {
        if (kicking) return;
        if ((playerMovement.GetMovementMode() == MovementMode.Running)) ToggleRun();
        kicking = true;
        playerAnimation.StartKick();
    }
}