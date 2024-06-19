namespace CsabaDu.DoesNotThrowTestDemo;

public class ParamValidator
{
    public void Validate([DoesNotReturnIf(false)] bool isValid)
    {
        //ArgumentOutOfRangeException.ThrowIfNotEqual(isValid, true, nameof(isValid));

        if (isValid) return;

        throw new ArgumentOutOfRangeException(nameof(isValid));
    }

    private void DoSomething(object? value)
    {
        throw new Exception();
    }

    private object? _newProperty;

    public object? NewProperty
    {
        get => _newProperty;
        set
        {
            try
            {
                DoSomething(value);

                _newProperty = value;
            }
            catch (Exception)
            {
                _newProperty = null;
            }
        }
    }

}
