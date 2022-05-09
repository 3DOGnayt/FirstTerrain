using System.Collections;
using UnityEditor;
using UnityEngine;

public class Window : EditorWindow
{
    [SerializeField]
    [Header("���������� ����������")]
    [Range(0, 100)]
    [Tooltip("�������� ��������� � ��������� �� 0 �� 100")]
    private int mySlider = 1; // ��������� ����������������� ��������
    [SerializeField]
    [TextArea(5, 10)]
    private string my2Slider;

    public Color myColor;         // �������� �����
    public MeshRenderer GO;      // ������ �� ������ �������

    public Material newMat;
    public Transform mainCam;
    private Rect AreaRect = new Rect(10, 30, 200, 20); 

    [MenuItem("����������� / ����")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Window), false, "�������� ����");
    }

    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Mesh", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMat = EditorGUILayout.ObjectField("Material", newMat, typeof(Material), true) as Material;

        if (GO)
        {
            mySlider = (int)LabelSlider(new Rect(AreaRect.x + 10, AreaRect.y + 30, 200, 20), mySlider, 0, 100, "My Hp"); // ��������� ����������������� ��������
            myColor = RGBSlider(new Rect(AreaRect.x + 10, AreaRect.y + 50, 200, 20), myColor);  // ��������� ����������������� ������ ��������� ��� ��������� ��������� �����
            GO.material.color = myColor; // �������� ������� 
        }
        else
        {
            if (GUILayout.Button("Create"))
            {
                mainCam = Camera.main.transform;
                GameObject main = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MeshRenderer GoRenderer = main.GetComponent<MeshRenderer>();
                GoRenderer.sharedMaterial = newMat;
                main.transform.position = new Vector3(mainCam.position.x, mainCam.position.y, mainCam.position.z + 10f);

                GO = GoRenderer;
            }
        }
        
    }

    // ��������� ����������������� �������� 
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue,string labelText) // �� �������� MinValue
    {        
        // ������ ������������� � ������������ � ������������ � ������� ������� � ������� 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // ������ Label �� ������

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // ����� ������� ��������
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // ������������ ������� � ��������� ��� ��������
        return sliderValue; // ���������� �������� ��������
    }

    // ��������� ������� ������� ������, ������ ������� �������� �� ���� ����  
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // ��������� ���������������� �������, ������ ��� 
        rgb.r = LabelSlider(screenRect, rgb.r, 0.1f, 1.0f, "Red");
                
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0.01f, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0.01f, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0.01f, 1.0f, "alpha");

        return rgb; // ���������� ����
    }

}
