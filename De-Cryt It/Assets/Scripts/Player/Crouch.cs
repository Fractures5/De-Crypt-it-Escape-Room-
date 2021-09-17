using UnityEngine;

public class Crouch : MonoBehaviour
{

    [Header("Slow Movement")]
    [Tooltip("Movement to slow down when crouched.")]
    public FirstPersonMovement movement;
    [Tooltip("Movement speed when crouched.")]
    public float movementSpeed = 0.3f;

    [Header("Low Head")]
    [Tooltip("Head to lower when crouched.")]
    public Transform headToLower;
    [HideInInspector]
    public float? defaultHeadYLocalPosition;
    public float crouchYHeadPosition = 1;
    
    [Tooltip("Collider to lower when crouched.")]
    public CapsuleCollider colliderToLower;
    [HideInInspector]
    public float? defaultColliderHeight;

    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;


    void Reset()
    {
        // Try to get components.
        movement = GetComponentInParent<FirstPersonMovement>();
        headToLower = movement.GetComponentInChildren<Camera>().transform;
        colliderToLower = movement.GetComponentInChildren<CapsuleCollider>();
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isCrouch();        
            if (!IsCrouched)
            {
            IsCrouched = true;
            SetSpeedOverrideActive(true);
            CrouchStart?.Invoke();
            }
        }
        else
        {
            Stand();
            if (IsCrouched)
            {
            IsCrouched = false;
            SetSpeedOverrideActive(false);
            CrouchEnd?.Invoke();
            }
        }
        // Set IsCrouched state.


    }

    //Method to reduce height
    void isCrouch()
    {
        colliderToLower.height = 0.5f;
    }

    //Method to reset playerheight after crouching
    void Stand()
    {
        colliderToLower.height = 2.0f;
    }

    #region Speed override.
    void SetSpeedOverrideActive(bool state)
    {
        // Stop if there is no movement component.
        if(!movement)
        {
            return;
        }

        // Update SpeedOverride.
        if (state)
        {
            // Try to add the SpeedOverride to the movement component.
            if (!movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Add(SpeedOverride);
            }
        }
        else
        {
            // Try to remove the SpeedOverride from the movement component.
            if (movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Remove(SpeedOverride);
            }
        }
    }

    float SpeedOverride() => movementSpeed;
    #endregion
}
