using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightBulbManager : MonoBehaviour
{
    [SerializeField]
    bool CanDebug = false;

    [SerializeField]
    List<MaterialEditor> lightBulbs;

    [SerializeField]
    List<Material> resultColours;

    [SerializeField]
    List<MeshRenderer> resultLamps;

    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    List<Color> activeColours = new List<Color>();
    [SerializeField] List<Material> colorOrder;

    [SerializeField] UnityEvent VictoryEvent, NoVictoryEvent;

    private int GoodMatches;

    // Start is called before the first frame update
    void Start()
    {
        activeColours = new List<Color>();

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
            if (CanDebug) Debug.Log("CURRENT COLOUR:  " + lightBulbs[iColor].Mpb.GetColor("_EmissionColor"));
            if (CanDebug) Debug.Log("WANTED COLOUR:   " + colorOrder[iColor].GetColor("_EmissionColor"));

            if(lightBulbs[iColor].Mpb.GetColor("_EmissionColor") == colorOrder[iColor].GetColor("_EmissionColor") * 1.5f)
            {                
                matchingLights++;

            }
        }

        ResultLampCounter(matchingLights);

        Debug.Log("Matching Lights:   " + matchingLights);

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

    private void ResultLampCounter(int burningLights)
    {
        mpb = new MaterialPropertyBlock();
        for (int iMatch = 0; iMatch < resultLamps.Count; iMatch++)
        {
            renderer = resultLamps[iMatch];
            renderer.GetPropertyBlock(mpb);
            mpb.SetColor("_EmissionColor", (iMatch < burningLights)? resultColours[1].GetColor("_EmissionColor") * 1.5f : resultColours[0].GetColor("_EmissionColor") * 1.5f);
            renderer.SetPropertyBlock(mpb);
        }
    }
}