using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightBulbManager : MonoBehaviour
{
    [SerializeField]
    List<MaterialEditor> lightBulbs;
    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    List<Color> activeColours = new List<Color>();
    [SerializeField] List<Material> colorOrder;

    [SerializeField] UnityEvent VictoryEvent, NoVictoryEvent;

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
        Victory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DoColoursMatch()
    {
        int matchingLights = 0;
        for (int iColor = 0; iColor < colorOrder.Count; iColor++)
        {
            Debug.Log("CURRENT COLOUR:  " + lightBulbs[iColor].Mpb.GetColor("_EmissionColor"));
            Debug.Log("WANTED COLOUR:   " + colorOrder[iColor].GetColor("_EmissionColor"));

            if(lightBulbs[iColor].Mpb.GetColor("_EmissionColor") == colorOrder[iColor].GetColor("_EmissionColor") * 1.5f)
            {
                Debug.Log("Match!");
                matchingLights++;
            }
        }

        Debug.Log("Matching Lights: " + matchingLights);

        return matchingLights >= colorOrder.Count;
    }

    private void Victory()
    {
        if (DoColoursMatch() == true)
        {
            VictoryEvent?.Invoke();
        }
        if (DoColoursMatch() == false)
        {
            NoVictoryEvent?.Invoke();
        }
    }
}