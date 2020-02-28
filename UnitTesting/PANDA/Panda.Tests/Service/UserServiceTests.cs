using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Panda.Tests.Service
{
    public class UserServiceTests
    {
        [Fact]
        public void TestGetAllUsers_WithTestData_ShouldReturnAllUsers()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new PandaDbContext(options);
            SeedTestData(context);

            var usersService = new UsersService(context);

            var actualData = usersService.GetAllUsers();
            var expextedData = GetTestData();

            Assert.Equal(expextedData.Count, actualData.Count);

            foreach (var actualUser in actualData)
            {
                Assert.True(expextedData.Any(user =>
                    actualUser.UserName == user.UserName
                    && actualUser.Email == user.Email
                    && actualUser.UserRole.Name == user.UserRole.Name), "UserService GetAllUsers() method does not work properly");
            }
        }
        
        
        [Fact]
        public void TestGetAllUsers_WithoutAnyData_ShouldReturnEmptyList()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new PandaDbContext(options);

            var usersService = new UsersService(context);

            var actualData = usersService.GetAllUsers();

            Assert.True(actualData.Count == 0, "UserService GetAllUsers() method does not work properly");
        }

        [Fact]
        public void TestGetAllUsers_WithExistenUsername_ShouldReturnUser()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new PandaDbContext(options);
            SeedTestData(context);

            var usersService = new UsersService(context);

            var testUsername = "TestUser1";

            var expectedData = GetTestData().SingleOrDefault(user => user.UserName == testUsername);
            var actualData = usersService.GetUser(testUsername);

            Assert.Equal(expectedData.UserName, actualData.UserName);
            Assert.Equal(expectedData.Email, actualData.Email);
            Assert.Equal(expectedData.UserRole.Name, actualData.UserRole.Name);
        }
        
        [Fact]
        public void TestGetAllUsers_WithNonExistenUsername_ShouldReturnNull()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new PandaDbContext(options);
            SeedTestData(context);

            var usersService = new UsersService(context);

            var testUsername = "TestUser5";

            var actualData = usersService.GetUser(testUsername);

            Assert.Null(actualData);
        }

        private void SeedTestData(PandaDbContext context)
        {
            context.Users.AddRange(GetTestData());
            context.SaveChanges();
        }

        private List<PandaUser> GetTestData()
        {
            return new List<PandaUser>
            {
                new PandaUser
                {
                    UserName = "TestUser1",
                    Email = "testUser1@email.com",
                    UserRole = new PandaUserRole{Name = "Admin"}
                },
                new PandaUser
                {
                    UserName = "TestUser2",
                    Email = "testUser2@email.com",
                    UserRole = new PandaUserRole{Name = "User"}
                }
            };
        }
    }
}