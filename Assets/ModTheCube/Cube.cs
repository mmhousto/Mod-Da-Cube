/*
 * 
 *    __    __     __    __     ______     __     __  __    
 *   /\ "-./  \   /\ "-./  \   /\  ___\   /\ \   /\_\_\_\   
 *   \ \ \-./\ \  \ \ \-./\ \  \ \___  \  \ \ \  \/_/\_\/_  
 *    \ \_\ \ \_\  \ \_\ \ \_\  \/\_____\  \ \_\   /\_\/\_\ 
 *     \/_/  \/_/   \/_/  \/_/   \/_____/   \/_/   \/_/\/_/ 
 *                                                     
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;
    private float randX, randY, randZ, randR, randG, randB, randA, randScale, randSpeed1, randSpeed2, randSpeed3;
    private Color randColor, randBGColor;
    private Vector3 randPos;
    private Vector3 randRot;
    private Camera cam;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        GetRandomValues();
    }
    void Start()
    {
        cam = Camera.main;
        cam.backgroundColor = ReturnRandomColor();

        transform.position = randPos;
        transform.localScale = Vector3.one * randScale;
        
        material = meshRenderer.material;
        
        material.color = randColor;
        InvokeRepeating(nameof(GetRandomColor), 0f, 3f);
        InvokeRepeating(nameof(GetRotationalSpeed), 0f, 3f);
        InvokeRepeating(nameof(GetRandomScale), 0f, 3f);
        InvokeRepeating(nameof(GetRandomPosition), 0f, 3f);
        InvokeRepeating(nameof(ChangeBackgroundColor), 0f, 3f);
    }
    
    void Update()
    {
        ChangeDirection();

        ChangeColors();

        ChangeScale();

        ChangePosition();
    }

    /// <summary>
    /// Assigns random values for position, size, color and rotaion speeds.
    /// </summary>
    void GetRandomValues()
    {
        GetRandomPosition();

        GetRandomColor();

        GetRandomScale();

        GetRotationalSpeed();
    }

    /// <summary>
    /// Gets random color.
    /// </summary>
    void GetRandomColor()
    {
        // Color
        randR = Random.Range(0, 1.0f);
        randG = Random.Range(0, 1.0f);
        randB = Random.Range(0, 1.0f);
        randA = Random.Range(0.33f, 1.0f);
        randColor = new Color(randR, randG, randB, randA);
    }

    /// <summary>
    /// Gets random color.
    /// </summary>
    Color ReturnRandomColor()
    {
        // Color
        randR = Random.Range(0, 1.0f);
        randG = Random.Range(0, 1.0f);
        randB = Random.Range(0, 1.0f);
        randA = Random.Range(0.33f, 1.0f);
        randBGColor = new Color(randR, randG, randB, randA);
        return randBGColor;
    }

    /// <summary>
    /// Gets random position in camera view.
    /// </summary>
    void GetRandomPosition()
    {
        // Position
        randX = Random.Range(-5.0f, 5.0f);
        randY = Random.Range(-5.0f, 5.0f);
        randZ = Random.Range(-5.0f, 5.0f);
        randPos = new Vector3(randX, randY, randZ);
    }

    void GetRandomScale()
    {
        // Scale
        randScale = Random.Range(1f, 6f);
    }

    void GetRotationalSpeed()
    {
        // Rotational Speed
        randSpeed1 = Random.Range(5f, 20f);
        randSpeed2 = Random.Range(5f, 20f);
        randSpeed3 = Random.Range(5f, 20f);
        randRot = new Vector3(randSpeed1, randSpeed2, randSpeed3);
    }

    /// <summary>
    /// Updates Rotation
    /// </summary>
    void ChangeDirection()
    {
        transform.Rotate(randRot * Time.deltaTime);
    }

    /// <summary>
    /// Updates Color gradually.
    /// </summary>
    void ChangeColors()
    {
        material.color = Color.Lerp(material.color, randColor, 0.2f * Time.deltaTime);
    }

    /// <summary>
    /// Updates scale gradually.
    /// </summary>
    void ChangeScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * randScale, 0.2f * Time.deltaTime);
    }

    /// <summary>
    /// Updates position gradually.
    /// </summary>
    void ChangePosition()
    {
        transform.position = Vector3.Lerp(transform.position, randPos, 0.2f * Time.deltaTime);
    }

    /// <summary>
    /// Updates Background Color.
    /// </summary>
    void ChangeBackgroundColor()
    {
        cam.backgroundColor = ReturnRandomColor();
    }
}
