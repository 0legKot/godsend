﻿namespace API.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Godsend;
    using Godsend.Controllers;
    using Godsend.Models;
    using Moq;
    using Xunit;
    public class EntityControllerTests
    {
        [Fact]
        public void AllTest()
        {
            var repo = new Mock<IProductRepository>();
            var info0 = new ProductInformation() { Id = Guid.NewGuid() };
            var info1 = new ProductInformation() { Id = Guid.NewGuid() };
            var info2 = new ProductInformation() { Id=Guid.NewGuid() };
            var info3 = new ProductInformation() { Id = Guid.NewGuid() };

            repo.Setup(x => x.EntitiesInfo(2, 2))
                .Returns(new List<Information>()
                {
                    info2,info3
                });

            var controller = new ProductController(repo.Object);

            IEnumerable<Information> result = controller.All(2,2);

            Assert.True(result.Any(x => x.Id == info2.Id)
                    && result.Any(x => x.Id == info3.Id)
                    && !result.Any(x => x.Id == info1.Id) 
                    && !result.Any(x => x.Id == info0.Id)
                );
        }

        [Fact]
        public void CountTest()
        {
            var repo = new Mock<IProductRepository>();
            var info0 = new ProductInformation() { Id = Guid.NewGuid() };
            var info1 = new ProductInformation() { Id = Guid.NewGuid() };
            var info2 = new ProductInformation() { Id = Guid.NewGuid() };
            var info3 = new ProductInformation() { Id = Guid.NewGuid() };

            repo.Setup(x => x.EntitiesCount())
                .Returns(4);

            var controller = new ProductController(repo.Object);

            int result = controller.Count();

            Assert.True(result == 4);
        }

        [Fact]
        public void DeleteTest()
        {
            var repo = new Mock<IProductRepository>();
            var info0 = new ProductInformation() { Id = Guid.NewGuid() };
            var info1 = new ProductInformation() { Id = Guid.NewGuid() };
            var info2 = new ProductInformation() { Id = Guid.NewGuid() };
            var info3 = new ProductInformation() { Id = Guid.NewGuid() };

            repo.Setup(x => x.DeleteEntity(info1.Id));

            var controller = new ProductController(repo.Object);
            controller.Delete(info1.Id);
            controller.Delete(info1.Id);
            Assert.True(true);
            }
    }
}
