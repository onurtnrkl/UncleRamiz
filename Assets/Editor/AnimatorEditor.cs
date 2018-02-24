#region License
/*================================================================
Product:    TapEngine
Developer:  Onur Tanrıkulu
Date:       29/11/2017 22:30

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.Animations;
using UnityEngine;

[CustomEditor(typeof(AnimatorController), false)]
public class AnimatorEditor : Editor
{
	private AnimatorController controller;
	private List<AnimationClip> clips;
	private string clipName;

	private void OnEnable()
	{
		controller = (AnimatorController)target;

		InitClips();
	}

	private void InitClips()
	{
		string path = AssetDatabase.GetAssetPath(controller);
		object[] assets = AssetDatabase.LoadAllAssetsAtPath(path);

		clips = new List<AnimationClip>();

		for (int i = 0; i < assets.Length; i++)
		{
			object asset = assets[i];

			if (asset is AnimationClip)
			{
				AnimationClip clip = (AnimationClip)asset;

				clips.Add(clip);
			}
		}
	}

	public override void OnInspectorGUI()
	{
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();

		clipName = EditorGUILayout.TextField(clipName);

		if (GUILayout.Button("+", EditorStyles.miniButton)) AddClip();

		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();

		DrawClips();
	}

	private void DrawClips()
	{
		for (int i = 0; i < clips.Count; i++) DrawClip(i);
	}

	private void DrawClip(int index)
	{
		EditorGUILayout.BeginHorizontal();

		AnimationClip clip = clips[index];

		EditorGUILayout.LabelField(clip.name, GUILayout.Width(100));

		if (GUILayout.Button("-", EditorStyles.miniButton)) RemoveClip(clip);

		EditorGUILayout.EndHorizontal();
	}

	private void AddClip()
	{
		AnimationClip clip = new AnimationClip();

		clip.name = clipName;
		AssetDatabase.AddObjectToAsset(clip, controller);
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(clip));
		clips.Add(clip);
		clipName = string.Empty;
	}

	private void RemoveClip(AnimationClip clip)
	{
		clips.Remove(clip);
		DestroyImmediate(clip, true);
		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(controller));
	}
}