using FirstWebProject.Data;
using FirstWebProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ProcentB.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider, float _procent = 0, string _bank_name = "", string _program_name = "")
    {
        using (var context = new interest_ratesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<interest_ratesContext>>()))
        {

            if (context.ProcentBase.Any())
            {
                return;
            }
            context.ProcentBase.AddRange(
                new ProcentBase
                {
                    procent = _procent,
                    bank_name = _bank_name,
                    program_name = _program_name
                });
            context.SaveChanges();
        }
    }
}