// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

public static class MissingMethodExceptionTests
{
    private const int COR_E_MISSINGMETHOD = unchecked((int)0x80131513);

    [Fact]
    public static void TestCtor_Empty()
    {
        var exception = new MissingMethodException();
        Assert.NotEmpty(exception.Message);
        Assert.Equal(COR_E_MISSINGMETHOD, exception.HResult);
    }

    [Fact]
    public static void TestCtor_String()
    {
        string message = "Created MissingMethodException";
        var exception = new MissingMethodException(message);
        Assert.Equal(message, exception.Message);
        Assert.Equal(COR_E_MISSINGMETHOD, exception.HResult);
    }

    [Fact]
    public static void TestCtor_Exception()
    {
        string message = "Created MissingMethodException";
        var innerException = new Exception("Created inner exception");
        var exception = new MissingMethodException(message, innerException);
        Assert.Equal(message, exception.Message);
        Assert.Equal(COR_E_MISSINGMETHOD, exception.HResult);
        Assert.Same(innerException, exception.InnerException);
        Assert.Equal(innerException.HResult, exception.InnerException.HResult);
    }
}
