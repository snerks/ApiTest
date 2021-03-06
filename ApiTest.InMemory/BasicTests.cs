using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTest.InMemory
{
    public class BasicTests
    {
        [Fact]
        public async Task CanGetHomePage()
        {
            // Arrange
            //
            // DLL is here:
            // C:\D\SamplesCore22\ApiTest\ApiTest.InMemory\bin\Debug\netcoreapp2.2\*.dll
            // 
            // ../ = C:\D\SamplesCore22\ApiTest\ApiTest.InMemory\bin\Debug\netcoreapp2.2
            // ../ = C:\D\SamplesCore22\ApiTest\ApiTest.InMemory\bin\Debug
            // ../ = C:\D\SamplesCore22\ApiTest\ApiTest.InMemory\bin
            // ../ = C:\D\SamplesCore22\ApiTest\ApiTest.InMemory
            // ../ = C:\D\SamplesCore22\ApiTest (i.e. Solution folder)

            // DLL is here:
            // ~\ApiTest\ApiTest.InMemory\bin\Debug\netcoreapp2.2\*.dll
            // 
            // ../ = ~\ApiTest\ApiTest.InMemory\bin\Debug\netcoreapp2.2
            // ../ = ~\ApiTest\ApiTest.InMemory\bin\Debug
            // ../ = ~\ApiTest\ApiTest.InMemory\bin
            // ../ = ~\ApiTest\ApiTest.InMemory
            // ../ = ~\ApiTest (i.e. Solution folder)
            //var contentRootPath = Path.GetFullPath("../../../../../ApiTest");
            //var contentRootPath = Path.GetFullPath("../../../../../ApiTest/ApiTest");

            var webHostBuilder =
                Program
                .CreateWebHostBuilder(Array.Empty<string>());
                // .UseContentRoot(contentRootPath);

            var server = new TestServer(webHostBuilder);
            var client = server.CreateClient();

            // Act
            var response = await client.GetAsync("/api/eventInfos");

            var contentString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
