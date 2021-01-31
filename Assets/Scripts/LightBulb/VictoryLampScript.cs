using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLampScript: MonoBehaviour
{
    [SerializeField]
    bool CanDebug = false;

    [SerializeField]
    List<Material> LightColours;

    [SerializeField]
    AudioSource VictorySound;
    
    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    public MaterialPropertyBlock Mpb => mpb;

    public System.Action<Color> onChangeColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        mpb = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(mpb);

        //mpb.SetColor("_EmissionColor", Color.cyan);
                     
        if (CanDebug) Debug.Log(LightColours);

    }

    private void Update()
    {
        
    }

    public void TurnOn()
    {
        mpb.SetColor("_EmissionColor", LightColours[1].GetColor("_EmissionColor") * 1.5f);
        renderer.SetPropertyBlock(mpb);

        VictorySound.Play();
    }

    public void TurnOff()
    {
        mpb.SetColor("_EmissionColor", LightColours[0].GetColor("_EmissionColor") * 1.5f);
        renderer.SetPropertyBlock(mpb);
    }
}