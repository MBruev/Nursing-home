using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

	[SerializeField] private Transform headTarget;

	//скорость движения
	public float speed = 6.0f;
	//гравитация
	public float gravity = -9.8f;

	private CharacterController _charController;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Получаем вектор движения
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		_animator.SetFloat ("Speed", movement.sqrMagnitude);

		//Добавляем гравитацию в наш вектор
		movement.y = gravity;

		//Контролируем нашу скорость перемешения от характеристик ПК
		movement *= Time.deltaTime;

		//переходим к глобальным координатам
		movement = transform.TransformDirection(movement);
		_charController.Move (movement);
		Camera.main.transform.position = headTarget.transform.position;
	}
}
