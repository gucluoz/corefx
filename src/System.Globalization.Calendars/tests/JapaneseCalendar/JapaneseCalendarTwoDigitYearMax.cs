// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.Globalization.CalendarsTests
{
    public class JapaneseCalendarTwoDigitYearMax
    {
        [Fact]
        public void TwoDigitYearMax_Get()
        {
            Assert.Equal(99, new JapaneseCalendar().TwoDigitYearMax);
        }
        
        [Theory]
        [InlineData(200)]
        [InlineData(99)]
        public void TwoDigitYearMax_Set(int newTwoDigitYearMax)
        {
            Calendar calendar = new JapaneseCalendar();
            calendar.TwoDigitYearMax = newTwoDigitYearMax;
            Assert.Equal(newTwoDigitYearMax, calendar.TwoDigitYearMax);
        }
    }
}
