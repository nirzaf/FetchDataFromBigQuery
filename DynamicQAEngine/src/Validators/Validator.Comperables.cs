using System;
using System.Collections.Generic;

namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfGreaterThan<TValue>(
        TValue value,
        TValue other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
        where TValue : notnull, IComparable
    {
        if (Comparer<TValue>.Default.Compare(value, other) > 0)
        {
            ExceptionThrower.ThrowOutOfRange(
                paramName,
                value,
                exceptionCustomizations,
                $"Value should not be greater than {other}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfLessThan<TValue>(
        TValue value,
        TValue other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
        where TValue : notnull, IComparable
    {
        if (Comparer<TValue>.Default.Compare(value, other) < 0)
        {
            ExceptionThrower.ThrowOutOfRange(
                paramName,
                value,
                exceptionCustomizations,
                $"Value should not be less than {other}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotInRange<TValue>(
        TValue value,
        TValue min,
        TValue max,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
        where TValue : notnull, IComparable
    {
        if (Comparer<TValue>.Default.Compare(value, min) < 0 || Comparer<TValue>.Default.Compare(value, max) > 0)
        {
            ExceptionThrower.ThrowOutOfRange(
                paramName,
                value,
                exceptionCustomizations,
                $"Value should be between {min} and {max}.");
        }
    }
}