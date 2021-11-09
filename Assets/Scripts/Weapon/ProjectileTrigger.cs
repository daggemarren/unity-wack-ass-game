using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileTrigger : MonoBehaviour
{

	public GameObject m_Projectile;    // this is a reference to your projectile prefab
	public Transform m_SpawnTransform; // this is a reference to the transform where the prefab will spawn
	public float rateOfFire = 0.05f; 
	private PlayerInput playerInput;
	bool isFire1;
	bool allowfire = true;
	
	private void Awake() {
		playerInput = new PlayerInput();
		playerInput.Player.Fire1.performed += Fire1;
		playerInput.Player.Fire1.canceled += Fire1;
	}

	private void Fire1(InputAction.CallbackContext context)
	{
		isFire1 = context.ReadValueAsButton();
	}

	private void Update()
	{
		if (WeaponHandler.isWeaponInHand && isFire1 && allowfire)
		{
			StartCoroutine(FireRate());
		}
	}

	IEnumerator FireRate()
	{
		allowfire = false;
		Instantiate(m_Projectile, m_SpawnTransform.position, m_SpawnTransform.rotation);
		yield return new WaitForSeconds(rateOfFire);
		allowfire = true;
	}

	void OnEnable() => playerInput.Player.Enable();

	void OnDisable() => playerInput.Player.Disable();
}
