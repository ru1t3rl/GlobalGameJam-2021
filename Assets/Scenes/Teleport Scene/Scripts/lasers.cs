using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class lasers : MonoBehaviour
{
    [SerializeField] private GameObject gunPlatform;
    [SerializeField] private GameObject laserBeamPfb;
    private GameObject cylinder;

    [SerializeField] private GameObject target;
    [SerializeField] private List<GameObject> guns;
    [SerializeField] private float chargeTime;

    [SerializeField] private bool fired;
    [SerializeField] private float laserSpeed;
    [SerializeField] private bool charging;

    [SerializeField] private float timer;
    [SerializeField] private float waitTime;

    [SerializeField] private Material shaderMaterial;
    [SerializeField] private Color aColor;
    [SerializeField] private Color bColor;

    void Start()
    {
        fired = true;
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            RandomFire();
        }
    }
    void OnTriggerEnter(Collider player)
    {
        string playerCol = player.gameObject.tag;
        if (playerCol == "Player")
        {
            gunPlatform.GetComponent<CanRotate>().canRotate = true;
            RandomFire();
        }
    }
    void RandomFire()
    {
        if (charging == false && fired == true)
        {
            StartCoroutine("LaserCharge");
        }
        else
        {
            Debug.Log("charging " + Time.deltaTime);
        }
    }
    void LaserFire(GameObject gun)
    {
        Vector3 originalPos = gun.transform.GetChild(0).transform.position;
        gun.transform.GetChild(0).Translate(Vector3.up * 25f);    
        Debug.Log("Firing Gun " + gun);
        fired = true;
        StartCoroutine(LaserDestroy(gun, originalPos));
    }
    private IEnumerator LaserCharge()
    {
        charging = true;
        int selectGun = Random.Range(0, guns.Count);
        float randomWait = Random.Range(6f, 9f);

        yield return new WaitForSeconds(randomWait);
        for (float i = 0.01f; i < randomWait; i += 0.1f)
        {
            guns[selectGun].gameObject.GetComponent<MeshRenderer>().material.color =
                Color.Lerp(aColor, bColor, i / randomWait);
            yield return null;
        }
        LaserFire(guns[selectGun].gameObject);
    }
    IEnumerator ColorLerpOut(GameObject gun)
    {
        for (float i = 0.01f; i < waitTime; i += 0.1f)
        {
            gun.gameObject.GetComponent<MeshRenderer>().material.color =
                Color.Lerp(bColor, aColor, i / waitTime);
            yield return null;
        }
    }
    private IEnumerator LaserDestroy(GameObject gun, Vector3 originalPosition)
    {
        if (fired)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(ColorLerpOut(gun.gameObject));     
            gun.transform.GetChild(0).transform.position = originalPosition;
            charging = false;
            //RandomFire();
        }
    }
}

