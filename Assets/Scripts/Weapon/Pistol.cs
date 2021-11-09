using UnityEngine;

public class Pistol : MonoBehaviour
{
    GameObject weaponSlot;

	void Awake()
	{
		weaponSlot = GameObject.FindWithTag("Weaponslot");
	}

	private void OnTriggerStay(Collider other) {
		if(other.tag == "Player") {
			Debug.Log("EQUIP");
			transform.parent = weaponSlot.transform;
			transform.localPosition = Vector3.zero;
			Quaternion targetRotation = Quaternion.Euler(0, -90.0f, 0);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
			WeaponHandler.isWeaponInHand = true;
		}
	}
}
