namespace CorsoGestioneDB.Application.Models;

public class NormalizeResult<T> where T : IComparable<T>?
{
    public T? Value { get; private set; }
    public T? OriginalValue { get; private set; }
    public bool Changed { get; private set; }

    public NormalizeResult(T? originalValue, T? normalizedValue)
    {
        this.Value = normalizedValue;
        this.OriginalValue = originalValue;

        // Confronta i due valori gestendo correttamente anche i tipi null
        this.Changed = !EqualityComparer<T>.Default.Equals(originalValue, normalizedValue);
    }
}