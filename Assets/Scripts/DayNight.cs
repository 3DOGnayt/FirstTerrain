using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public class LightSettings : MonoBehaviour
    {
        [SerializeField]
        Color Sky, Equator, Ground, SunColor; // Цвета солнца, и Ambient Skybox

        [SerializeField]
        float RotateSpeed; // Скорость вращения солнца

        Light Sun; // Ссылка на источник освещения

        void Start()
        {
            Sun = GetComponent<Light>();
        }

        void Update()
        {
            // Настраиваем Ambient Skybox Color
            RenderSettings.ambientSkyColor = Sky;
            RenderSettings.ambientGroundColor = Ground;
            RenderSettings.ambientEquatorColor = Equator;
            // Настраиваем цвет солнца
            Sun.color = SunColor;
            // Вращаем солнце
            transform.Rotate(transform.right, RotateSpeed, Space.Self);
        }
    }

}
