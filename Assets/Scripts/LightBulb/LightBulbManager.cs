using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbManager : MonoBehaviour
{
    [SerializeField]
    List<MaterialEditor> lightBulbs;
    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    List<Color> activeColours = new List<Color>();
    [SerializeField] List<Color> colorOrder;

    // Start is called before the first frame update
    void Start()
    {
        activeColours = new List<Color>();

        renderer = GetComponent<MeshRenderer>();

        for (int i = 0; i < lightBulbs.Count; i++)
        {
            lightBulbs[i].onChangeColor += OnColorChanged;
        }
    }

    void OnColorChanged(Color color)
    {
        activeColours.Clear();

        for (int i = 0; i < lightBulbs.Count; i++)
        {
            activeColours.Add(lightBulbs[i].Mpb.GetColor("_EmissionColor"));
        }
        DoColoursMatch();
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool DoColoursMatch()
    {
        int matchingLights = 0;
        for (int iColor = 0; iColor < colorOrder.Count; iColor++)
        {
            if(lightBulbs[iColor].Mpb.GetColor("_EmissionColor") == colorOrder[iColor])
            {
                matchingLights++;
            }
        }

        return matchingLights >= colorOrder.Count;
    }

    private void Victory()
    {
        if (DoColoursMatch() == true)
        {
            //Open The Door
        }
    }

}