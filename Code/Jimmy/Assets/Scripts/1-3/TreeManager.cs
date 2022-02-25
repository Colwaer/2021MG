using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public DraggableObjPlus semiCircle;
    public DraggableObjPlus diamond;
    public DraggableObjPlus tShape;
    public DraggableObjPlus hollowSquare;
    public DraggableObjPlus triangle;
    public DraggableObjPlus rectangle;

    public Transform attachPoint1;
    public Transform attachPoint2;
    public Transform attachPoint3;

    public Fade tree1;
    public Fade tree2;
    public Fade tree3;

    bool mix1;
    bool mix2;
    bool mix3;


    private void Update()
    {
        if (Vector2.Distance(triangle.transform.position, rectangle.transform.position) < 0.3f)
        {
            if (!mix1)
            {
                mix1 = true;
                triangle.GetComponent<Fade>().StartFade();
                rectangle.GetComponent<Fade>().StartFade();
                triangle.enableDrag = false;
                rectangle.enableDrag = false;
                tree1.StartFade();
                tree1.transform.position = triangle.transform.position;
                tree1.GetComponent<DraggableObjPlus>().enableDrag = true;
            }
        }
        if (Vector2.Distance(semiCircle.transform.position, diamond.transform.position) < 0.3f)
        {
            if (!mix2)
            {
                mix2 = true;
                semiCircle.GetComponent<Fade>().StartFade();
                diamond.GetComponent<Fade>().StartFade();
                semiCircle.enableDrag = false;
                diamond.enableDrag = false;
                tree2.StartFade();
                tree2.transform.position = semiCircle.transform.position;
                tree2.GetComponent<DraggableObjPlus>().enableDrag = true;
            }
        }
        if (Vector2.Distance(hollowSquare.transform.position, tShape.transform.position) < 0.3f)
        {
            if (!mix3)
            {
                mix3 = true;
                hollowSquare.GetComponent<Fade>().StartFade();
                tShape.GetComponent<Fade>().StartFade();
                hollowSquare.enableDrag = false;
                tShape.enableDrag = false;
                tree3.StartFade();
                tree3.transform.position = hollowSquare.transform.position;
                tree3.GetComponent<DraggableObjPlus>().enableDrag = true;
            }
        }



    }
    

}
