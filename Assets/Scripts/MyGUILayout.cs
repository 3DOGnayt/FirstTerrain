using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyGUILayout : MonoBehaviour
{
    private float sliderValue; // значение слайдера
   

    void OnGUI()
    {
        // Кнопки с авто размером и положением
        GUILayout.Button("Automatic Layout Button");      
        
        GUILayout.Button("I am not inside an Area");

        // Создаём группу слайдеров в заданном месте и заданным размером
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
        GUILayout.Button("I am inside an Area"); // Кнопка внутри группы с авто размером и положением
       
        GUILayout.BeginHorizontal();  // Начало строчного заполнения

        GUILayout.BeginVertical();  // Начало столбцового заполнения

        if (GUILayout.RepeatButton("Min"))
            sliderValue = 0.0f;
        if (GUILayout.RepeatButton("Max"))
            sliderValue = 10.0f;


        GUILayout.Button("Overridden Button", GUILayout.Width(120));
       
        GUILayout.EndVertical();  // Конец столбцового заполнения

        GUILayout.BeginVertical();  // Начало столбцового заполнения
        GUILayout.Label("Some slider: ");
        sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, 10.0f);
        GUILayout.EndVertical();  // Конец столбцового заполнения

        GUILayout.EndHorizontal();  // Конец строчного заполнения
        GUILayout.EndArea();      
    }
}
