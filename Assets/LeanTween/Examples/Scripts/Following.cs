﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

    public Transform planet;

    public Transform followArrow;

    public Transform dude1;
    public Transform dude2;
    public Transform dude3;
    public Transform dude4;
    public Transform dude5;

    public Transform dude1Title;
    public Transform dude2Title;
    public Transform dude3Title;
    public Transform dude4Title;
    public Transform dude5Title;

    private Color dude1ColorVelocity;

    private Material followMaterial;
    private Vector3 velocityPos;

    private void Start()
    {
        followMaterial = followArrow.GetComponent<Renderer>().material;

        followArrow.gameObject.LeanDelayedCall(3f, moveArrow).setOnStart(moveArrow).setRepeat(-1);

        // Follow Local Y Position of Arrow
        LeanTween.followDamp(dude1, followArrow, LeanProp.localY, 1.1f);
        LeanTween.followSpring(dude2, followArrow, LeanProp.localY, 1.1f);
        LeanTween.followBounceOut(dude3, followArrow, LeanProp.localY, 1.1f);
        LeanTween.followSpring(dude4, followArrow, LeanProp.localY, 1.1f, -1f, 1.5f, 0.8f);
        LeanTween.followLinear(dude5, followArrow, LeanProp.localY, 50f);

        // Follow Arrow color
        LeanTween.followDamp(dude1, followArrow, LeanProp.color, 1.1f);
        LeanTween.followSpring(dude2, followArrow, LeanProp.color, 1.1f);
        LeanTween.followBounceOut(dude3, followArrow, LeanProp.color, 1.1f);
        LeanTween.followSpring(dude4, followArrow, LeanProp.color, 1.1f, -1f, 1.5f, 0.8f);
        LeanTween.followLinear(dude5, followArrow, LeanProp.color, 0.5f);

        // Follow Arrow scale
        LeanTween.followDamp(dude1, followArrow, LeanProp.scale, 1.1f);
        LeanTween.followSpring(dude2, followArrow, LeanProp.scale, 1.1f);
        LeanTween.followBounceOut(dude3, followArrow, LeanProp.scale, 1.1f);
        LeanTween.followSpring(dude4, followArrow, LeanProp.scale, 1.1f, -1f, 1.5f, 0.8f);
        LeanTween.followLinear(dude5, followArrow, LeanProp.scale, 5f);

        // Titles
        var titleOffset = new Vector3(0.0f, -20f, -18f);
        LeanTween.followDamp(dude1Title, dude1, LeanProp.localPosition, 0.6f).setOffset(titleOffset);
        LeanTween.followSpring(dude2Title, dude2, LeanProp.localPosition, 0.6f).setOffset(titleOffset);
        LeanTween.followBounceOut(dude3Title, dude3, LeanProp.localPosition, 0.6f).setOffset(titleOffset);
        LeanTween.followSpring(dude4Title, dude4, LeanProp.localPosition, 0.6f, -1f, 1.5f, 0.8f).setOffset(titleOffset);
        LeanTween.followLinear(dude5Title, dude5, LeanProp.localPosition, 30f).setOffset(titleOffset);

        // Rotate Planet
        var localPos = Camera.main.transform.InverseTransformPoint(planet.transform.position);
        LeanTween.rotateAround(Camera.main.gameObject, Vector3.left, 360f, 300f).setPoint(localPos).setRepeat(-1);
    }


    private void Update()
    {
        // dude2.GetComponent<Renderer>().material.color = LeanTween.smoothGravity(dude2.GetComponent<Renderer>().material.color, followMaterial.color, ref dude1ColorVelocity, 1.1f);
        //dude1Title.localPosition = Vector3.SmoothDamp(dude1Title.localPosition, dude2.localPosition, ref velocityPos, 1.1f);
        //Debug.Log("1:" + dude1Title.position + " 2:" + dude2.position);
    }

	private void moveArrow()
    {
        LeanTween.moveLocalY(followArrow.gameObject, Random.Range(-100f, 100f), 0f);

        var randomCol = new Color(Random.value, Random.value, Random.value);
        LeanTween.color(followArrow.gameObject, randomCol, 0f);

        var randomVal = Random.Range(5f, 10f);
        followArrow.localScale = Vector3.one * randomVal;
    }
}
