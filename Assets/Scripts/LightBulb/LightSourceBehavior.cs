using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightSourceBehavior : MonoBehaviour
{
    [SerializeField]
    bool CanDebug = false;

    [SerializeField] MaterialEditor mEditor;
    Light light;

    private void Awake()
    {
        mEditor.onChangeColor += OnColorChanged;
        light = GetComponent<Light>();
    }

    private void OnColorChanged(Color color)
    {
        light.color = color;
    }
}
