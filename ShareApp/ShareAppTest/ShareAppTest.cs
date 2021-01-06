using FluentAssertions;
using Ian.ShareApp;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Ian.ShareAppTest
{
    public class ShareAppTest
    {
        [Fact]
        public void ApplicationExists()
        {
            _ = new ShareApplication(new List<User>());
        }
    }
}
