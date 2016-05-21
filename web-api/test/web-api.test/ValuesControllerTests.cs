﻿using Xunit;

namespace web_api.test
{
    public class ValuesControllerTests
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}