using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class VisonCone : MonoBehaviour
{
    public Material coneMaterial;

    [SerializeField] private float coneRange = 2f;
    [SerializeField] private float coneHeight = 1f;
    [Tooltip("Measured in degrees."), SerializeField] private float coneAngle = 60f;

    [SerializeField] private LayerMask obstructionLayers;
    [SerializeField] private int resolution = 120;

    private Mesh coneMesh;
    private MeshFilter meshFilter;

    private int[] tris;
    private Vector3[] verts;

    [SerializeField] private ZombieController zombieController;

    public void Awake()
    {
        coneMesh = new Mesh();

        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = coneMaterial;
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mr.receiveShadows = false;

        meshFilter = gameObject.AddComponent<MeshFilter>();

        coneAngle *= Mathf.Deg2Rad;

        tris = new int[(resolution - 1) * 3];
        verts = new Vector3[resolution + 1];

        if (zombieController == null) zombieController = GetComponentInParent<ZombieController>();
    }

    public void LateUpdate()
    {
      //  if (zombieController.Target == null)
      CreateConeMesh();
    }

    private void CreateConeMesh()
    {
        verts[0] = Vector3.up * coneHeight;

        float currentAngle = -coneAngle / 2;
        float angleIncrement = coneAngle / (resolution - 1);

        for (int i = 0; i < resolution; i++)
        {
            float sin = Mathf.Sin(currentAngle);
            float cos = Mathf.Cos(currentAngle);

            Vector3 dir = (transform.forward * cos) + (transform.right * sin);
            Vector3 vertFwd = (Vector3.forward * cos) + (Vector3.right * sin);

            Vector3 rayOrigin = transform.position + transform.up * coneHeight;
            if (Physics.Raycast(rayOrigin, dir, out RaycastHit hit, coneRange, obstructionLayers))
            {
                if (hit.collider.CompareTag("Villager"))
                {
                    zombieController.Target = hit.transform;
                    meshFilter.mesh = null;
                    print("Villager found");
                    print(zombieController.Target.name);
                    return;
                }

                verts[i + 1] = vertFwd * hit.distance + Vector3.up * coneHeight;
            }
            else
            {
                verts[i + 1] = vertFwd * coneRange + Vector3.up * coneHeight;
            }

            currentAngle += angleIncrement;
        }

        for (int i = 0, j = 0; i < tris.Length; i += 3, j++)
        {
            tris[i] = 0;
            tris[i + 1] = j + 1;
            tris[i + 2] = j + 2;
        }

        coneMesh.Clear();

        coneMesh.vertices = verts;
        coneMesh.triangles = tris;

        meshFilter.mesh = coneMesh;
    }
}
