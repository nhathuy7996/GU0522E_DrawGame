using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    LineRenderer _line;
    EdgeCollider2D _colli;
    Rigidbody2D _rigi;

    List<Vector3> _listPoint = new List<Vector3>();
    List<Vector2> _listLocalPoint = new List<Vector2>();
    Vector2 oldMousePos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        _line = this.GetComponent<LineRenderer>();
        _colli = this.GetComponent<EdgeCollider2D>();
        _rigi = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _listPoint.Clear();
            _listLocalPoint.Clear();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _rigi.simulated = true;
        }

        if (!Input.GetMouseButton(0))
            return;

       Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!oldMousePos.Equals(mousePos))
        {
            _listPoint.Add(mousePos - (Vector2)this.transform.position);
            _listLocalPoint.Add(mousePos - (Vector2)this.transform.position);
            oldMousePos = mousePos;
        }

        _line.positionCount = _listPoint.Count;
        _line.SetPositions(_listPoint.ToArray());
        _colli.SetPoints(_listLocalPoint);
    }
}
