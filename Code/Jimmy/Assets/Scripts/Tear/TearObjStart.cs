using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearObjStart : MonoBehaviour, IClickable
{
	public Material frontMaterial;
	public Material backMaterial;
	List<line> lines = new List<line>();
	List<Vector2> onList = new List<Vector2>();
	List<Vector2> upList = new List<Vector2>();
	List<Vector2> downList = new List<Vector2>();
	List<Vector3> part1Vertices = new List<Vector3>();
	List<Vector3> part2Vertices = new List<Vector3>();
	SpriteRenderer spriteRenderer;

	public AK.Wwise.Event sound;
	Vector2[] vertices;
	Vector2[] intersectionPointsList;

	Vector2 startPos;
	Vector2 endPos;

	Vector2 TargetPos;
	Vector2 HalfTargetPos;

	Vector2 leftUpPoint;

	line drawnLine;


	float xLength, yLength;

	//public GameObject pointHinter;

	GameObject UpperFather;

	GameObject meshObj;
	GameObject meshObjBack;
	MeshRenderer meshRenderer;
	MeshFilter meshFilter;
	MeshRenderer meshRendererBack;
	MeshFilter meshFilterBack;
	Mesh mesh;
	Mesh meshBack;

	GameObject meshObj2;
	GameObject meshObjBack2;
	MeshRenderer meshRenderer2;
	MeshFilter meshFilter2;
	MeshRenderer meshRendererBack2;
	MeshFilter meshFilterBack2;
	Mesh mesh2;
	Mesh meshBack2;

	Vector2 rotatePoint;
	float thisOriginK;

	public Vector2 startPosOffset;
	public Vector2 endPosOffset;

	public bool enableTearBack = true;
	public bool Stop = true;
	public bool TearDown = false;

	public float startTime = 0.5f;
	public float firstClickProcess = 0.2f;
	public float secondClickProcess = 0.6f;

	public int tearProgress = 0;
	


	private float originFirstClickProcess;
	private float originSecondClickProcess;

	//public bool firstTime = true;

	public float point1 = 0.1f, point2 = 0.9f;
	public float EndTime = 2.8f;
	

	public float z = -0.0005f;

	public float tearDis = 0.6f;
	public float tearSpeed = 1.0f;

	float timer;
	float originMouseYPos;
	bool startDrag;
	float tearDir = 1f;
	
	float originK;
	line originLine;
	float degree;
	bool rotated;
	Vector2 deltaVec;
	float time;
	Vector2 start;
	Vector2 end;

	bool couratineEnd = true;

	new Collider2D collider;

	private void Awake()
	{
		collider = GetComponent<Collider2D>();

		spriteRenderer = GetComponent<SpriteRenderer>();

		meshObj = new GameObject("MeshObj");
		meshObjBack = new GameObject("MeshObjBack");
		meshRenderer = meshObj.AddComponent<MeshRenderer>();
		meshFilter = meshObj.AddComponent<MeshFilter>();
		meshRendererBack = meshObjBack.AddComponent<MeshRenderer>();
		meshFilterBack = meshObjBack.AddComponent<MeshFilter>();
		meshRenderer.material = frontMaterial;
		meshRendererBack.material = backMaterial;
		mesh = new Mesh();
		meshBack = new Mesh();




		meshObj2 = new GameObject("MeshObj");
		meshObjBack2 = new GameObject("MeshObjBack");
		meshRenderer2 = meshObj2.AddComponent<MeshRenderer>();
		meshFilter2 = meshObj2.AddComponent<MeshFilter>();
		meshRendererBack2 = meshObjBack2.AddComponent<MeshRenderer>();
		meshFilterBack2 = meshObjBack2.AddComponent<MeshFilter>();
		meshRenderer2.material = frontMaterial;
		meshRendererBack2.material = backMaterial;
		mesh2 = new Mesh();
		meshBack2 = new Mesh();

		vertices = GetVerticesFromPolygonCollider();
		leftUpPoint = vertices[0];

		UpperFather = new GameObject("UpperFather");
		UpperFather.transform.position = Vector3.zero;
		CreateOriginPolygonLine();


		Vector3 meshobj2Pos = meshObj2.transform.position;
		Vector3 meshobj2BackPos = meshObjBack2.transform.position;

		meshObj2.transform.position = new Vector3(meshobj2Pos.x, meshobj2Pos.y, -0.07f);
		meshObjBack2.transform.position = new Vector3(meshobj2BackPos.x, meshobj2BackPos.y, -0.07f);

		Vector3 meshobjPos = meshObj.transform.position;
		Vector3 meshobjBackPos = meshObjBack.transform.position;

		meshObj.transform.position = new Vector3(meshobjPos.x, meshobjPos.y, 2f);
		meshObjBack.transform.position = new Vector3(meshobjBackPos.x, meshobjBackPos.y, 2f);




		originFirstClickProcess = firstClickProcess;
		originSecondClickProcess = secondClickProcess;

		//StartCoroutine(IChangeTarPos(3f, vertices[0], vertices[1] * point1 + vertices[2] * point2));
		TearInit(3f, vertices[0] + startPosOffset, vertices[1] * point2 + vertices[2] * point1 + endPosOffset);
		//StartCoroutine(IChangeTarPos(3f, vertices[0] + startPosOffset, vertices[1] * point2 + vertices[2] * point1 + endPosOffset));
	}
    
    private void Update()
	{
		if (startDrag)
        {
			float yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
			if (originMouseYPos - yPos > tearDis)
            {
				TearDownFunc();
				startDrag = false;

			}
			else if (originMouseYPos - yPos < -tearDis)
            {
				Debug.LogWarning("tearUp");
				TearUpFunc();
				startDrag = false;
            }


		}
	}
	private void TearInit(float time, Vector2 start, Vector2 end)
    {
		this.time = time;
		this.start = start;
		this.end = end;
		originK = -(float)(end.x - start.x) / (float)(end.y - start.y);
		this.thisOriginK = originK;
		originLine = new line(start, originK);
		degree = 360f - (90f + Mathf.Atan(originK) * Mathf.Rad2Deg) * 2;
		rotated = false;
		//if (!firstTime)
		//	rotated = true;
		spriteRenderer.enabled = false;
		deltaVec = (end - start) / time * Time.fixedDeltaTime * tearSpeed;
		timer = 0;
		TargetPos = start;
		StartCoroutine(IChangeTarPos(startTime));
	}
	private void TearDownFunc()
    {
		if (tearProgress == 3)
        {
			return;
		}
		sound.Post(gameObject);
		tearProgress++;
		tearDir = 1f;
		if (tearProgress == 1)
        {
			StartCoroutine(IChangeTarPos(firstClickProcess));
        }
		else if (tearProgress == 2)
        {
			StartCoroutine(IChangeTarPos(secondClickProcess));
        }
		else if (tearProgress == 3)
        {
			StartCoroutine(IChangeTarPos(EndTime - startTime - firstClickProcess - secondClickProcess));
		}
		if (tearProgress == 3)
        {
			
			if (!enableTearBack)
            {
				collider.enabled = false;
            }
		}
			
    }
	private void TearUpFunc()
    {
		

		TearDown = false;
		if (tearProgress == 0)
			return;

		sound.Post(gameObject);
		tearProgress--;
		tearDir = -1f;
		if (tearProgress == 0)
		{
			StartCoroutine(IChangeTarPos(firstClickProcess));
		}
		else if (tearProgress == 1)
		{
			StartCoroutine(IChangeTarPos(secondClickProcess));
		}
		else if (tearProgress == 2)
		{
			
			StartCoroutine(IChangeTarPos(EndTime - startTime - firstClickProcess - secondClickProcess));
		}

	}
	

    #region ˺ֽ�ײ�
    void CreateMeshObj(List<Vector3> points, Mesh mesh, Mesh meshBack, MeshFilter meshFilter, MeshFilter meshFilterBack)
	{

		Vector3[] meshVertices = points.ToArray();
		Vector3[] meshVertices2 = points.ToArray();
		int[] meshTriangles;
		int[] meshTriangles2;
		Vector2[] meshUv = null;

		
		if (points.Count == 4)
		{
			meshTriangles = new int[] { 0, 1, 2, 0, 2, 3 };
			meshTriangles2 = new int[] { 2, 1, 0, 3, 2, 0 };

			mesh.vertices = meshVertices;
			meshBack.vertices = meshVertices2;
			mesh.triangles = meshTriangles;
			meshBack.triangles = meshTriangles2;
			meshUv = new Vector2[4];
			for (int i = 0; i < 4; i++)
			{
				meshUv[i] = new Vector2((meshVertices[i].x - vertices[1].x) / xLength, (meshVertices[i].y - vertices[1].y) / yLength);
			}
		}
		else
		{
			meshTriangles = new int[] { 0, 1, 2 };
			meshTriangles2 = new int[] { 2, 1, 0 };
			mesh.vertices = meshVertices;
			meshBack.vertices = meshVertices2;
			mesh.triangles = meshTriangles;
			meshBack.triangles = meshTriangles2;
			meshUv = new Vector2[3];
			for (int i = 0; i < 3; i++)
			{
				meshUv[i] = new Vector2((meshVertices[i].x - vertices[1].x) / xLength, (meshVertices[i].y - vertices[1].y) / yLength);
			}
		}

		mesh.uv = meshUv;
		meshBack.uv = meshUv;

		meshFilter.mesh = mesh;
		meshFilterBack.mesh = meshBack;
	}
	void DividePoints(line l)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector2 v = vertices[i];

			if (l.GetY(v.x) - v.y > 0.05f)
				downList.Add(v);
			else if (l.GetY(v.x) - v.y < -0.05f)
				upList.Add(v);
			else
				onList.Add(v);
		}
		for (int i = 0; i < intersectionPointsList.Length; i++)
		{
			Vector2 v = intersectionPointsList[i];

			if (l.GetY(v.x) - v.y > 0.05f)
				downList.Add(v);
			else if (l.GetY(v.x) - v.y < -0.05f)
				upList.Add(v);
			else
				onList.Add(v);
		}
		for (int i = 0; i < upList.Count; i++)
		{
			part1Vertices.Add(upList[i]);
		}
		for (int i = 0; i < downList.Count; i++)
		{
			part2Vertices.Add(downList[i]);
		}
		for (int i = 0; i < onList.Count; i++)
		{
			part1Vertices.Add(onList[i]);
			part2Vertices.Add(onList[i]);
		}

		Compare cmp = new Compare();
		cmp.DeliverFirstPoint(part1Vertices);
		part1Vertices.Sort(cmp);
		cmp.DeliverFirstPoint(part2Vertices);
		part2Vertices.Sort(cmp);





	}
	// 得到 与直线l的交点，取在四边形上的部分 
	Vector2[] GetIntersectionPoints(line l)
	{
		Vector2[] vectors = new Vector2[5];
		int index = 0;
		for (int i = 0; i < lines.Count; i++)
		{
			Vector2 v = lines[i].CrossPoint(l);

			if (lines[i].Inside)
			{
				//Instantiate(pointHinter).transform.position = v;
				vectors[index++] = v;
			}
		}

		Vector2[] ret = new Vector2[index];
		for (int i = 0; i < index; i++)
			ret[i] = vectors[i];
		return ret;
	}

	Vector2[] GetVerticesFromPolygonCollider()
	{
		PolygonCollider2D collider = gameObject.GetComponent<PolygonCollider2D>();
		Vector2[] vertices = collider.points;

		for (int i = 0; i < vertices.Length; i++)
		{
			Vector2 ver = vertices[i];
			ver = new Vector2(ver.x * transform.localScale.x, ver.y * transform.localScale.y);
			ver = new Vector2(ver.x + transform.position.x, ver.y + transform.position.y);
			vertices[i] = ver;
		}
		xLength = Mathf.Abs(Vector2.Distance(vertices[2], vertices[1]));
		yLength = Mathf.Abs(Vector2.Distance(vertices[1], vertices[0]));
		return vertices;
	}
	void CreateOriginPolygonLine()
	{
		// ֻ�ܵ���һ��


		for (int i = 0; i < vertices.Length; i++)
		{
			if (i != vertices.Length - 1)
				lines.Add(new line(vertices[i], vertices[i + 1]));
			else
				lines.Add(new line(vertices[i], vertices[0]));


		}
	}
    #endregion
    public void OnMouseButtonDown()
    {
		if (!couratineEnd)
			return;
		startDrag = true;
		originMouseYPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }

    public void OnMouseButtonUp()
    {
		startDrag = false;
	}
	IEnumerator IChangeTarPos(float duration)
	{
		couratineEnd = false;
		float iChangeTarTimer = 0f;
		while (iChangeTarTimer < duration)
		{
			iChangeTarTimer += Time.fixedDeltaTime;
			onList.Clear();
			downList.Clear();
			upList.Clear();
			part1Vertices.Clear();
			part2Vertices.Clear();
			TargetPos += deltaVec * tearDir;
			HalfTargetPos = (TargetPos + start) / 2;
			line newLine = new line(HalfTargetPos, originK);
			intersectionPointsList = GetIntersectionPoints(newLine);
			DividePoints(newLine);
			if (part1Vertices.Count != 4 || part2Vertices.Count != 4)
				continue;

			if (!rotated)
			{
				
				rotated = true;
				rotatePoint = HalfTargetPos;
				Vector3 axis = new Vector3(1, originK, 0);
				meshObj.transform.RotateAround(rotatePoint, axis, 180f);
				meshObjBack.transform.RotateAround(rotatePoint, axis, 180f);
				Debug.Log("Successfully created");
			}
			else
			{
				meshObj.transform.position += new Vector3(deltaVec.x, deltaVec.y, z) * tearDir;
				meshObjBack.transform.position += new Vector3(deltaVec.x, deltaVec.y, z) * tearDir;
			}
			CreateMeshObj(part1Vertices, mesh, meshBack, meshFilter, meshFilterBack);
			CreateMeshObj(part2Vertices, mesh2, meshBack2, meshFilter2, meshFilterBack2);
			yield return new WaitForFixedUpdate();
		}
		if (tearProgress == 3)
			TearDown = true;
		couratineEnd = true;
	}
}
