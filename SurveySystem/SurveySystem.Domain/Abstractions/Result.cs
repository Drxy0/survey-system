using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SurveySystem.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }
        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        isSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    // new() - Calls the constructor of the derived class Result<TValue> : Result
    // Static Methods Are Inherited by Result<TValue>
    // This doesn't normally work, but since the methods are static, this can work
    // Apart from the fact that Result does not know about its derived class
    // A non-static method works on the current instance (this)
    // The static method bypasses the need for an instance (this) entirely
    //
    // SIGNATURE:
    // public static Result<TValue> Success(TValue value) { ... }
    // This signature works only if the class is generic, since it is not
    // we need to add <TValue> to Success<TValue>
    // TValue needs to be defined at class level
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    // Simpler rewrite that replaces these 3 methods
    public static Result<TValue> CreateSimple<TValue>(TValue? value)
    {
        if (value != null)
        {
            return new Result<TValue>(value, true, Error.None);
        }
        else
        {
            return new Result<TValue>(default, false, Error.NullValue);
        }
    }
}

public class Result<TValue> : Result
{
    // Holds the actual value when the result is successful
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    // Used by the higher layers, (usually API) for checking if the value is valid
    // This is a property with only a { get; }
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    
    // implicit operator keywords define a implicit conversion operator,
    // which converts one type to another
    // implicit means it will convert automatically, without needing a cast
    // In this case it converts TValue? value to Result<TValue>
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}