﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (CompositeBehavior))]
public class CompositeBehaviorEditor : Editor {
    private FlockBehavior adding;

    private FlockBehavior[] Remove (int index, FlockBehavior[] old) {
        // Remove this behaviour
        var current = new FlockBehavior[old.Length - 1];

        for (int y = 0, x = 0; y < old.Length; y++) {
            if (y != index) {
                current[x] = old[y];
                x++;
            }
        }

        return current;
    }

    public override void OnInspectorGUI () {
        // Setup
        var current = (CompositeBehavior) target;
        EditorGUILayout.BeginHorizontal ();

        // Draw
        if (current.behaviors == null || current.behaviors.Length == 0) {
            EditorGUILayout.HelpBox ("No behaviors attached.", MessageType.Warning);
            EditorGUILayout.EndHorizontal ();
        } else {
            EditorGUILayout.LabelField ("Behaviors");
            EditorGUILayout.LabelField ("Weights");

            EditorGUILayout.EndHorizontal ();

            for (int i = 0; i < current.behaviors.Length; i++) {
                // Draw index
                EditorGUILayout.BeginHorizontal ();

                if (GUILayout.Button ("Remove") || current.behaviors[i] == null) {
                    // Remove this behaviour
                    current.behaviors = Remove (i, current.behaviors);
                    break;
                }

                current.behaviors[i] = (FlockBehavior) EditorGUILayout.ObjectField (current.behaviors[i], typeof (FlockBehavior), false);
                EditorGUILayout.Space (30);
                current.weights[i] = EditorGUILayout.Slider (current.weights[i], 0, 1);

                EditorGUILayout.EndHorizontal ();
            }
        }

        EditorGUILayout.EndHorizontal ();

        EditorGUILayout.BeginHorizontal ();
        EditorGUILayout.LabelField ("Add behaviour...");
        EditorGUILayout.EndHorizontal ();
        EditorGUILayout.BeginHorizontal ();

        adding = (FlockBehavior) EditorGUILayout.ObjectField (adding, typeof (FlockBehavior), false);

        if (adding != null) {
            // add this item to the array
            var oldBehaviors = current.behaviors;
            current.behaviors = new FlockBehavior[oldBehaviors.Length + 1];
            var oldWeights = current.weights;
            current.weights = new float[oldWeights.Length + 1];

            for (int i = 0; i < oldBehaviors.Length; i++) {
                current.behaviors[i] = oldBehaviors[i];
                current.weights[i] = oldWeights[i];
            }

            current.behaviors[oldBehaviors.Length] = adding;
            current.weights[oldWeights.Length] = 1;

            adding = null;
        }
    }
}