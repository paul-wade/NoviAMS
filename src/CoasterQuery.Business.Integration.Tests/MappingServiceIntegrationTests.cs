using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoasterQuery.Business.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoasterQuery.Business.Integration.Tests
{
    [TestClass]
    public class MappingServiceIntegrationTests
    {

        [TestMethod]
        public async Task MappingService_GetLatLong_ShouldReturnResult()
        {
            //1600 Pennsylvania Avenue, Washington DC
            var underTest = new MappingService();
            var result = await underTest.GetLatLong("1600 Pennsylvania Avenue", "Washington", "DC", "20006");
            result.Should().NotBeNull();
       
        }

    }
}
