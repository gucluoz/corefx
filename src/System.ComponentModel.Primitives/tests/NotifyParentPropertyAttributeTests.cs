﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.ComponentModel.Primitives.Tests
{
    public class NotifyParentPropertyAttributeTests
    {
        [Fact]
        public void Equals_DifferentValues()
        {
            Assert.False(NotifyParentPropertyAttribute.Yes.Equals(NotifyParentPropertyAttribute.No));
        }

        [Fact]
        public void Equals_SameValue()
        {
            Assert.True(NotifyParentPropertyAttribute.Yes.Equals(NotifyParentPropertyAttribute.Yes));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetNotifyParent(bool value)
        {
            var attribute = new NotifyParentPropertyAttribute(value);

            Assert.Equal(value, attribute.NotifyParent);
        }
    }
}