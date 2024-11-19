using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float sensitivity = 2f; // Чувствительность вращения
    private float rotationX = 0f; // Угол вращения по оси X
    private float rotationY = 0f; // Угол вращения по оси Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Скрыть курсор
    }

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Обновляем углы вращения
        rotationX -= mouseY;
        rotationY += mouseX;

        // Ограничиваем угол вращения по оси X
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        // Применяем вращение к камере
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
