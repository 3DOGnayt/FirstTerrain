using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public class LightSettings : MonoBehaviour
    {
        [SerializeField]
        Color Sky, Equator, Ground, SunColor; // ����� ������, � Ambient Skybox

        [SerializeField]
        float RotateSpeed; // �������� �������� ������

        Light Sun; // ������ �� �������� ���������

        void Start()
        {
            Sun = GetComponent<Light>();
        }

        void Update()
        {
            // ����������� Ambient Skybox Color
            RenderSettings.ambientSkyColor = Sky;
            RenderSettings.ambientGroundColor = Ground;
            RenderSettings.ambientEquatorColor = Equator;
            // ����������� ���� ������
            Sun.color = SunColor;
            // ������� ������
            transform.Rotate(transform.right, RotateSpeed, Space.Self);
        }
    }

}
