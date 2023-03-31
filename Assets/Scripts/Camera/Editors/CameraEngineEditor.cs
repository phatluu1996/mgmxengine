using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(CameraEngine))]
public class CameraEngineEditor : Editor
{
    private CameraEngine m_Target;
    private SerializedProperty m_FollowModuleProperty;
    private SerializedProperty m_RoomModuleProperty;
    private void OnEnable()
    {

        m_FollowModuleProperty = serializedObject.FindProperty("m_FollowModule");
        m_RoomModuleProperty = serializedObject.FindProperty("m_RoomModule");
        m_Target = (CameraEngine)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        if (m_Target == null) return;

        Handles.color = Color.green;
        int i = 0;

        foreach (Room room in m_Target.m_RoomModule.Rooms)
        {

            Handles.color = Color.white;

            Handles.DrawWireCube(room.Rectangle.Center, room.Rectangle.Size);
            Vector2 center = room.Rectangle.Center;
            Vector2 size = room.Rectangle.Size;

            EditorGUI.BeginChangeCheck();
            
            center = Handles.PositionHandle(center, Quaternion.identity);
            
            // Handles.ArrowHandleCap
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(m_Target, "Adjust Room Rectangle");

                room.Rectangle.Center = center;
                room.Rectangle.Update(center);
            }

            EditorGUI.BeginChangeCheck();
            
            Handles.RectangleHandleCap(0, room.Rectangle.TR - Vector2.one * 8, Quaternion.identity, 8, EventType.Repaint);
            size = Handles.FreeMoveHandle(0, room.Rectangle.TR - Vector2.one * 8, 8, Vector3.one * 8, Handles.RectangleHandleCap);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(m_Target, "Adjust Room Rectangle");                
                room.Rectangle.Size = size;
                room.Rectangle.Update( room.Rectangle.Center, size);
            }
            i++;
        }
    }
}