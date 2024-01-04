using UnityEngine;

public class AutoTransition : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example: Automatically transition between animations based on time
        float time = Mathf.Repeat(Time.time, 3f); // Change 3f to the total time of your animations

        // Set the blend tree parameter to control the transition
        animator.SetFloat("BlendParameter", time);
    }
}
