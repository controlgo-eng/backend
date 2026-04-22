using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGo.Infrastructure.Repositories.EntityFramework
{
    public static class ModelBinderExtensions
    {
        public static void Seed(this ModelBuilder modelBinder)
        {
            //modelBinder.Entity<Entity>()
            //    .HasData(
            //        new Entity { ID = 1, Name = "Name", Description = "..." },
            //        new AddressType { ID = 2, Name = "N....", Description = "C..." },
        }
    }
}
