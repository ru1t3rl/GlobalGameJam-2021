using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultLightScript : MonoBehaviour
{
    [SerializeField]
    bool CanDebug = false;

    [SerializeField]
    List<Material> ResultColours;

    [SerializeField]
    List<GameObject> ResultLamps;

    MeshRenderer renderer;
    MaterialPropertyBlock mpb;
    public MaterialPropertyBlock Mpb => mpb;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        mpb = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(mpb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResultCorrect()
    {
        mpb.SetColor("_EmissionColor", ResultColours[1].GetColor("_EmissionColor") * 1.5f);
        renderer.SetPropertyBlock(mpb);

    }

    public void ResultIncorrect()
    {
        mpb.SetColor("_EmissionColor", ResultColours[0].GetColor("_EmissionColor") * 1.5f);
        renderer.SetPropertyBlock(mpb);
    }
}
