using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController instance = null;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform _selection;

    //Awake is always called before any Start functions
    private void Awake()
    {
        // Set instance to this once only.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Update()
    {
        // Deselection Logic
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;

                if (Input.GetMouseButtonDown(0))
                {
                    var eventController = selection.GetComponent<EventController>();
                    if (eventController != null)
                    {
                        eventController.TriggerEvent1();
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    var eventController = selection.GetComponent<EventController>();
                    if (eventController != null)
                    {
                        eventController.TriggerEvent2();
                    }
                }
            }

        }
    }

}
