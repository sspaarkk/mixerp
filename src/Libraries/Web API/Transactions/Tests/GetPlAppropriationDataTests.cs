// ReSharper disable All
using System;
using System.Diagnostics;
using System.Linq;
using MixERP.Net.Api.Transactions.Fakes;
using MixERP.Net.ApplicationState.Cache;
using Xunit;

namespace MixERP.Net.Api.Transactions.Tests
{
    public class GetPlAppropriationDataTests
    {
        public static GetPlAppropriationDataController Fixture()
        {
            GetPlAppropriationDataController controller = new GetPlAppropriationDataController(new GetPlAppropriationDataRepository(), "", new LoginView());
            return controller;
        }

        [Fact]
        [Conditional("Debug")]
        public void Execute()
        {
            var actual = Fixture().Execute(new GetPlAppropriationDataController.Annotation());
            Assert.NotNull(actual);
        }
    }
}