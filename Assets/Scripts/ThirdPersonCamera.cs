using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float distance = 5f;
    public float height = 0f;
    private float verticalAngle = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float rotateX = Input.GetAxis("Mouse X");
        float rotateY = Input.GetAxis("Mouse Y");

        // Поворот игрока влево-вправо
        player.Rotate(0, rotateX, 0);

        // Вертикальный угол камеры
        verticalAngle -= rotateY;
        verticalAngle = Mathf.Clamp(verticalAngle, -30f, 60f);

        // Позиция камеры за спиной игрока
        Quaternion rotation = Quaternion.Euler(verticalAngle, player.eulerAngles.y, 0);
        transform.position = player.position + rotation * new Vector3(0, height, -distance);

        // Камера всегда смотрит на игрока
        transform.LookAt(player.position + Vector3.up * height);
    }
}