using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;
using TMPro;
using Unity.Profiling.LowLevel.Unsafe;

public class ProfilerController : MonoBehaviour
{
    /************************************************************************************************************
    * Source: https://docs.unity3d.com/2020.2/Documentation/ScriptReference/Unity.Profiling.ProfilerRecorder.html
    *************************************************************************************************************/
    
    //public static ProfilerMarker UpdatePlayerProfilerMarker = new ProfilerMarker("Player.Update");

    [SerializeField] string statsText;
    ProfilerRecorder systemMemoryRecorder;
    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder mainThreadTimeRecorder;
    ProfilerRecorder drawCallsCountRecorder;
    ProfilerRecorder vertices;
    ProfilerRecorder triangles;

    static double GetRecorderFrameAverage(ProfilerRecorder recorder)
    {
        var samplesCount = recorder.Capacity;
        if (samplesCount == 0)
            return 0;

        double r = 0;
        var samples = new List<ProfilerRecorderSample>(samplesCount);
        recorder.CopyTo(samples);
        for (var i = 0; i < samples.Count; ++i)
            r += samples[i].Value;
        r /= samplesCount;

        return r;
    }

    void OnEnable()
    {
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        mainThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15);
        drawCallsCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
        vertices = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
        triangles = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");
        //GetAvailableProfilerStats.EnumerateProfilerStats();
    }

    void OnDisable()
    {
        systemMemoryRecorder.Dispose();
        gcMemoryRecorder.Dispose();
        mainThreadTimeRecorder.Dispose();
        drawCallsCountRecorder.Dispose();
        vertices.Dispose();
        triangles.Dispose();
    }

    void Update()
    {
        var sb = new StringBuilder(500);
        sb.AppendLine($"Frame Time: {GetRecorderFrameAverage(mainThreadTimeRecorder) * (1e-6f):F1} ms");
        sb.AppendLine($"GC Memory: {gcMemoryRecorder.LastValue / (1024 * 1024)} MB");
        sb.AppendLine($"System Memory: {systemMemoryRecorder.LastValue / (1024 * 1024)} MB");
        sb.AppendLine($"Draw Calls: {drawCallsCountRecorder.LastValue}");
        sb.AppendLine($"Vertices Count: {vertices.LastValue}");
        sb.AppendLine($"Triangles Count: {triangles.LastValueAsDouble}");
        statsText = sb.ToString();
    }

    void OnGUI()
    {
        
        GUI.TextArea(new Rect(10, 30, 250, 110), statsText);
    }
}