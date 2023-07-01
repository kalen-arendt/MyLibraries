using UnityEngine;

namespace My.Football.Unity.Fields.Drawing
{
   /// <summary>
   /// prefabs that are used to create parts of the field.
   /// </summary>
   [CreateAssetMenu(fileName = "Field Components", menuName = "Field/Field Components")]
   public class FieldComponents : ScriptableObject
   {
      [SerializeField] private GameObject defensivePenaltyArea;   // normal scale = defensive half orientation
      [SerializeField] private GameObject bottomLeftCornerArc; // normal scale = bottom left orientation
      [SerializeField] private GameObject centerCircle;
      [SerializeField] private GameObject goal;

      [SerializeField] private Sprite grass;
      [SerializeField] private LineRenderer lineRenderer;

      public GameObject Goal => goal;
      public GameObject PenaltyArea => defensivePenaltyArea;
      public GameObject CornerArc => bottomLeftCornerArc;
      public GameObject CenterCircle => centerCircle;
      public Sprite Grass => grass;
      public LineRenderer LineRenderer => lineRenderer;
   }
}