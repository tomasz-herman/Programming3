using System.Collections;

namespace Enumeration;

// Compiler-generated class for the iterator state machine
// This is how compiler will transform the method defined in Program.cs:
// (Variable names were modified to be more human-readable)
// private static IEnumerable<int> Fibonacci(int n)
sealed class FibonacciEnumerator : IEnumerable<int>, IEnumerator<int>
{
    private int state;         // To track the state of the state machine, initialized to 0
    private int current;       // Stores the current value for IEnumerator<T>.Current
    private int n;             // Stores the 'n' parameter value from Fibonacci(n)
    private int currentFib;    // Corresponds to 'current' variable in original method
    private int nextFib;       // Corresponds to 'next' variable in original method
    private int iteration;     // Loop variable to track iterations

    public FibonacciEnumerator(int n) 
    {
        this.n = n;            // Capture the input parameter 'n'
        this.currentFib = 0;   // Initialize 'current'
        this.nextFib = 1;      // Initialize 'next'
        this.iteration = 0;    // Initialize loop counter
    }

    public bool MoveNext()
    {
        switch (state)
        {
            case 0: // Initial state before first entry
                state = 1; // Advance to the running state
                break;

            case 1: // If state is 1, continue running
                break;

            case -1: // Final state (sequence complete)
                return false;

            default:
                return false;
        }

        // The main logic of Fibonacci generation
        if (iteration < n)
        {
            current = currentFib;                                      // The value to yield
            (currentFib, nextFib) = (nextFib, currentFib + nextFib);   // Update Fibonacci sequence
            iteration++;                                               // Move to next iteration

            state = 1;   // Ensure next time we are still in an active state            
            return true; // Signal that there's more to yield
        }
        
        // We've finished the sequence
        state = -1; // Set state to final state (-1) signaling completion
        return false; // No more values to yield
    }

    public int Current => current; // The last yielded value
    
    object IEnumerator.Current => current; // Explicit interface implementation

    public void Dispose() 
    {
        // Optionally implemented by the state machine, if needed (not required in simple iteration)
    }

    public void Reset() => throw new NotSupportedException(); // Reset is usually not supported for iterators

    public IEnumerator<int> GetEnumerator() => this;
    
    IEnumerator IEnumerable.GetEnumerator() => this;
}
