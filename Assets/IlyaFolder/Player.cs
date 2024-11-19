using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject selectedObject;
    private Camera mainCamera;
    private float pickupDistance = 2f;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левый клик мыши
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupDistance))
            {
                if (hit.transform.CompareTag("Pickup")) // Убедись, что объект имеет тег "Pickup"
                {
                    selectedObject = hit.transform.gameObject;
                    selectedObject.transform.SetParent(mainCamera.transform); // Привязываем объект к камере
                    selectedObject.GetComponent<Rigidbody>().isKinematic = true; // Отключаем физику
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject != null) // Отпускаем объект
        {
            selectedObject.transform.SetParent(null); // Отвязываем объект
            selectedObject.GetComponent<Rigidbody>().isKinematic = false; // Включаем физику
            selectedObject = null; // Сбрасываем выбранный объект
        }
        if (selectedObject != null) // Перемещение объекта с мышкой
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = pickupDistance; // Устанавливаем расстояние от камеры
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            selectedObject.transform.position = worldPosition; // Обновляем позицию объекта
        }
    }
}
