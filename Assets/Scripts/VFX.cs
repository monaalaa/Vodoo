using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VFXNames
{
    jumpVFX, 
    Diamond,
    Combo
}
public class VFX : MonoBehaviour
{
    public static VFX Instance;

    [SerializeField]
     GameObject jumpVFX;

    [SerializeField]
    GameObject Diamond;

    [SerializeField]
    GameObject Combo;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void CreateVFX(Quaternion rot, Vector3 pos, VFXNames name)
    {
        switch (name)
        {
            case VFXNames.jumpVFX:
                {
                    Instantiate(jumpVFX, pos, rot);
                    break;
                }
            case VFXNames.Diamond:
                {
                    Instantiate(Diamond, pos, rot);

                    break;
                }
            case VFXNames.Combo:
                {
                    Instantiate(Combo, pos, rot);
                    break;
                }
        }

    }
}
