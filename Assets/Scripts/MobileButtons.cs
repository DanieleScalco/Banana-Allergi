using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileButtons : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	public UnityEvent onLongPress = new UnityEvent();

	private bool isPointerDown = false;

	private void Update() {
		if (isPointerDown && !SpawnManager.isGameOver) {
			onLongPress.Invoke();
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		isPointerDown = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPointerDown = false;
	}


	public void OnPointerExit(PointerEventData eventData) {
		isPointerDown = false;
	}
}