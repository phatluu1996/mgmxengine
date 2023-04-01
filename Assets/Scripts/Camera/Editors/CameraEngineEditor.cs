using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(CameraEngine))]
public class CameraEngineEditor : Editor
{
    private CameraEngine m_Target;
    private SerializedProperty m_FollowModuleProperty;
    private SerializedProperty m_RoomModuleProperty;
    private SerializedProperty m_RoomsProperty;
    private SerializedProperty m_DefaultSizeProperty;
    private const float BOX_ROUNDING_RADIUS = 30f;
    int m_SelectedIndex = 0;
    private Color normalColor = new Color(0.1f, 0.1f, 0.1f, 0.5f);
    private Color activeColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
    private void OnEnable()
    {

        m_FollowModuleProperty = serializedObject.FindProperty("m_FollowModule");
        m_RoomModuleProperty = serializedObject.FindProperty("m_RoomModule");
        m_RoomModuleProperty.FindPropertyRelative("m_CameraEngine");
        m_Target = (CameraEngine)target;
        m_RoomsProperty = m_RoomModuleProperty.FindPropertyRelative("m_Rooms");
        m_DefaultSizeProperty = m_RoomModuleProperty.FindPropertyRelative("m_DefaultSize");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUIStyle boxStyle = GUI.skin.box;

        boxStyle.padding = new RectOffset(10, 10, 10, 10);
        boxStyle.border = new RectOffset((int)BOX_ROUNDING_RADIUS, (int)BOX_ROUNDING_RADIUS, (int)BOX_ROUNDING_RADIUS, (int)BOX_ROUNDING_RADIUS);

        DrawPropertiesExcluding(serializedObject, "m_RoomModule");

        m_RoomModuleProperty.isExpanded = EditorGUILayout.Foldout(m_RoomModuleProperty.isExpanded, "Room Module");
        if (m_RoomModuleProperty.isExpanded)
        {
            EditorGUI.indentLevel++;
            m_DefaultSizeProperty.vector2Value = EditorGUILayout.Vector2Field("Size", m_DefaultSizeProperty.vector2Value);

            EditorGUILayout.BeginHorizontal();
            m_RoomsProperty.arraySize = EditorGUILayout.IntField("Rooms", m_RoomsProperty.arraySize);
            if (GUILayout.Button("+", GUILayout.Width(60), GUILayout.Height(20)))
            {
                m_Target.m_RoomModule.AddRoom(m_Target.m_RoomModule.CreateRoom(m_Target.Position + Vector2.one * 16));
            }
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < m_RoomsProperty.arraySize; i++)
            {
                var element = m_RoomsProperty.GetArrayElementAtIndex(i);
                EditorGUI.indentLevel++;
                bool isElementSelected = (i == m_SelectedIndex);

                Rect boxRect = EditorGUILayout.BeginVertical("Box");

                EditorGUI.DrawRect(new Rect(boxRect.x, boxRect.y, boxRect.width, boxRect.height + 2), isElementSelected ? activeColor : normalColor);

                EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Select", GUILayout.Height(20), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(80)))
                {
                    m_SelectedIndex = i;
                }
                if (GUILayout.Button("-", GUILayout.Height(20), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(80)))
                {
                    m_Target.m_RoomModule.RemoveRoom(m_Target.m_RoomModule.Rooms[i]);
                }

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.PropertyField(element, true);
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

    private void OnSceneGUI()
    {
        if (m_Target == null) return;

        Handles.color = Color.green;
        for (int i = 0; i < m_Target.m_RoomModule.Rooms.Count; i++)
        {
            Room room = m_Target.m_RoomModule.Rooms[i];

            Rect rect = new Rect(room.Rectangle.BL, room.Rectangle.Size);
            // Handles.DrawWireCube(room.Rectangle.Center, room.Rectangle.Size);
            Handles.color = Color.cyan;
            Handles.DrawSolidRectangleWithOutline(rect, Color.clear, Color.white);
            Handles.color = Color.yellow;
            Handles.DrawDottedLine(new Vector2(room.Rectangle.R, room.Rectangle.CT.y), new Vector2(room.Rectangle.L, room.Rectangle.CT.y), m_Target.HandleSize / 2);
            Handles.DrawDottedLine(new Vector2(room.Rectangle.R, room.Rectangle.CB.y), new Vector2(room.Rectangle.L, room.Rectangle.CB.y), m_Target.HandleSize / 2);
            Handles.DrawDottedLine(new Vector2(room.Rectangle.CL.x, room.Rectangle.T), new Vector2(room.Rectangle.CL.x, room.Rectangle.B), m_Target.HandleSize / 2);
            Handles.DrawDottedLine(new Vector2(room.Rectangle.CR.x, room.Rectangle.T), new Vector2(room.Rectangle.CR.x, room.Rectangle.B), m_Target.HandleSize / 2);
            Vector2 center = room.Rectangle.Center;

            EditorGUI.BeginChangeCheck();

            // center = Handles.PositionHandle(center, Quaternion.identity);
            Handles.color = Color.red;
            Handles.RectangleHandleCap(i + 100, center, Quaternion.identity, 12, EventType.Repaint);
            center = Handles.FreeMoveHandle(i + 100, center, 12, Vector3.one * 8, Handles.RectangleHandleCap);


            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(m_Target, "Adjust Room Rectangle");                
                room.Rectangle.Update(center, room.Rectangle.Size);
            }


            DrawRectangleSizeHandle(i + 200, room, room.Rectangle.Center, EdgePosition.Top, m_Target.HandleSize);
            DrawRectangleSizeHandle(i + 300, room, room.Rectangle.Center, EdgePosition.Bottom, m_Target.HandleSize);
            DrawRectangleSizeHandle(i + 400, room, room.Rectangle.Center, EdgePosition.Left, m_Target.HandleSize);
            DrawRectangleSizeHandle(i + 500, room, room.Rectangle.Center, EdgePosition.Right, m_Target.HandleSize);


            DrawRectangleDeadZoneHandle(i + 600, room, room.Rectangle.CL + new Vector2(m_Target.HandleSize / 2, m_Target.HandleSize * 3 / 2), EdgePosition.Left, m_Target.HandleSize);
            DrawRectangleDeadZoneHandle(i + 700, room, room.Rectangle.CR + new Vector2(-m_Target.HandleSize / 2, m_Target.HandleSize * 3 / 2), EdgePosition.Right, m_Target.HandleSize);
            DrawRectangleDeadZoneHandle(i + 800, room, room.Rectangle.CT + new Vector2(m_Target.HandleSize * 3 / 2, -m_Target.HandleSize / 2), EdgePosition.Top, m_Target.HandleSize);
            DrawRectangleDeadZoneHandle(i + 900, room, room.Rectangle.CB + new Vector2(m_Target.HandleSize * 3 / 2, m_Target.HandleSize / 2), EdgePosition.Bottom, m_Target.HandleSize);

            Handles.color = Color.magenta;
            if(Handles.Button(room.Rectangle.BL + Vector2.one * m_Target.HandleSize, Quaternion.identity, m_Target.HandleSize, m_Target.HandleSize, Handles.RectangleHandleCap)){            
                room.Rectangle = new Rectangle(room.Rectangle.Center, room.m_RoomModule.DefaultSize);
            }
        }
        SceneView.RepaintAll();
    }

    public void DrawRectangleDeadZoneHandle(int controlerID, Room room, Vector2 position, EdgePosition edgePosition, float handleSize)
    {
        Vector2 center = room.Rectangle.Center;
        EditorGUI.BeginChangeCheck();
        Handles.color = Color.green;

        Handles.RectangleHandleCap(controlerID, position, Quaternion.identity, m_Target.HandleSize / 2, EventType.Repaint);
        Vector2 oldHandlePosition = position;
        Vector2 newHandlePosition = Handles.FreeMoveHandle(controlerID, oldHandlePosition, m_Target.HandleSize / 2, Vector3.one * 8, Handles.RectangleHandleCap);
        if (EditorGUI.EndChangeCheck())
        {

            Undo.RecordObject(m_Target, "Adjust Room Rectangle");
            switch (edgePosition)
            {
                case EdgePosition.Top:
                    newHandlePosition.y = Mathf.Clamp(newHandlePosition.y, center.y, room.Rectangle.T);
                    newHandlePosition.x = room.Rectangle.CT.x;
                    room.Rectangle.CT = newHandlePosition;
                    break;
                case EdgePosition.Bottom:
                    newHandlePosition.y = Mathf.Clamp(newHandlePosition.y, room.Rectangle.B, center.y);
                    newHandlePosition.x = room.Rectangle.CB.x;
                    room.Rectangle.CB = newHandlePosition;
                    break;

                case EdgePosition.Left:
                    newHandlePosition.x = Mathf.Clamp(newHandlePosition.x, room.Rectangle.L, center.x);
                    newHandlePosition.y = room.Rectangle.CL.y;
                    room.Rectangle.CL = newHandlePosition;
                    break;

                case EdgePosition.Right:
                    newHandlePosition.x = Mathf.Clamp(newHandlePosition.x, center.x, room.Rectangle.R);
                    newHandlePosition.y = room.Rectangle.CR.y;
                    room.Rectangle.CR = newHandlePosition;
                    break;
            }
        }
    }


    public void DrawRectangleSizeHandle(int controlerID, Room room, Vector2 position, EdgePosition edgePosition, float handleSize)
    {
        Handles.color = Color.yellow;
        Vector2 center = room.Rectangle.Center;
        Vector2 size = room.Rectangle.Size;
        EditorGUI.BeginChangeCheck();
        Vector2 offset = edgePosition switch
        {
            EdgePosition.Top => (room.Rectangle.Size.y * Vector2.up / 2) + Vector2.down * handleSize,
            EdgePosition.Bottom => (room.Rectangle.Size.y * Vector2.down / 2) + Vector2.up * handleSize,
            EdgePosition.Left => (room.Rectangle.Size.x * Vector2.left / 2) + Vector2.right * handleSize,
            EdgePosition.Right => (room.Rectangle.Size.x * Vector2.right / 2) + Vector2.left * handleSize,
            _ => Vector2.zero
        };

        Handles.RectangleHandleCap(controlerID, position + offset, Quaternion.identity, handleSize, EventType.Repaint);
        Vector2 oldHandlePosition = position + offset;
        Vector2 newHandlePosition = Handles.FreeMoveHandle(controlerID, position + offset, handleSize, Vector3.one * 8, Handles.RectangleHandleCap);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(m_Target, "Adjust Room Rectangle");
            switch (edgePosition)
            {
                case EdgePosition.Top:
                    size.y = size.y + (newHandlePosition.y - oldHandlePosition.y);
                    center.y = center.y + (newHandlePosition.y - oldHandlePosition.y) / 2;
                    break;
                case EdgePosition.Bottom:
                    size.y = size.y - (newHandlePosition.y - oldHandlePosition.y);
                    center.y = center.y + (newHandlePosition.y - oldHandlePosition.y) / 2;
                    break;

                case EdgePosition.Left:
                    size.x = size.x - (newHandlePosition.x - oldHandlePosition.x);
                    center.x = center.x + (newHandlePosition.x - oldHandlePosition.x) / 2;
                    break;

                case EdgePosition.Right:
                    size.x = size.x + (newHandlePosition.x - oldHandlePosition.x);
                    center.x = center.x + (newHandlePosition.x - oldHandlePosition.x) / 2;
                    break;
                default:
                    // Code to handle any other value
                    break;
            }
            room.Rectangle.Update(center, size);
        }
    }

    public enum EdgePosition
    {
        Top, Bottom, Left, Right
    }
}