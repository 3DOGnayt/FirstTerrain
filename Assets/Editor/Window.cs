using System.Collections;
using UnityEditor;
using UnityEngine;

public class Window : EditorWindow
{
    [SerializeField]
    [Header("Отладочная переменная")]
    [Range(0, 100)]
    [Tooltip("Значение находится в диапазоне от 0 до 100")]
    private int mySlider = 1; // Положение пользовательского слайдера
    [SerializeField]
    [TextArea(5, 10)]
    private string my2Slider;

    public Color myColor;         // Градиент цвета
    public MeshRenderer GO;      // Ссылка на рендер объекта

    public Material newMat;
    public Transform mainCam;
    private Rect AreaRect = new Rect(10, 30, 200, 20); 

    [MenuItem("Инструменты / Окна")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Window), false, "Тестовое окно");
    }

    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Mesh", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMat = EditorGUILayout.ObjectField("Material", newMat, typeof(Material), true) as Material;

        if (GO)
        {
            mySlider = (int)LabelSlider(new Rect(AreaRect.x + 10, AreaRect.y + 30, 200, 20), mySlider, 0, 100, "My Hp"); // Отрисовка пользовательского слайдера
            myColor = RGBSlider(new Rect(AreaRect.x + 10, AreaRect.y + 50, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
            GO.material.color = myColor; // Покраска объекта 
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

    // Отрисовка пользовательского слайдера 
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue,string labelText) // ДЗ добавить MinValue
    {        
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет  
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его 
        rgb.r = LabelSlider(screenRect, rgb.r, 0.1f, 1.0f, "Red");
                
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0.01f, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0.01f, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0.01f, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    }

}
