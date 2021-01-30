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
    AudioSource OpenSound;
    
    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    public MaterialPropertyBlock Mpb => mpb;

    int index = 0;

    public System.Action<Color> onChangeColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        mpb = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(mpb);

        //mpb.SetColor("_EmissionColor", Color.cyan);

        renderer.SetPropertyBlock(mpb);
              
        if (CanDebug) Debug.Log(LightColours);

    }

    private void Update()
    {
        //If the lamps match the order, initiate TurnOn()
    }

    public void TurnOn()
    {
        //Change material to On
    }

    //public void ChangeColour()
    //{
    //    index = (index + 1 < LightColours.Count) ? index + 1 : 0;
    //    if (CanDebug) Debug.Log($"{LightColours[index].color}");
    //    mpb.SetColor("_EmissionColor", LightColours[index].GetColor("_EmissionColor") * 1.5f);
    //    renderer.SetPropertyBlock(mpb);

    //    onChangeColor?.Invoke(LightColours[index].color);

    //    hitSound.Play();
    //    hitSound.pitch = index + 2;
    //    if (CanDebug) Debug.Log(hitSound.pitch);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Laser")
    //    {            
    //        ChangeColour();
    //    }
    //}
}