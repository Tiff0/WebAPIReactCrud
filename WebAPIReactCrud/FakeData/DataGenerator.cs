namespace WebAPIReactCrud.FakeData
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Models.Enums;

    /// <summary>
    ///     Fake data generator.
    /// </summary>
    public static class DataGenerator
    {
        /// <summary>
        ///     Generate DonationCandidates.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext =
                new DonationDbContext(serviceProvider.GetRequiredService<DbContextOptions<DonationDbContext>>()))
            {
                if (dbContext.DonationCandidates.Any())
                {
                    return;
                }

                dbContext.DonationCandidates.AddRange(
                    new DonationCandidate
                    {
                        Id = 1,
                        Address = "Russia",
                        Age = 30,
                        BloodGroupId = (int) EnumBloodGroup.A,
                        Email = "iivanov@react.com",
                        FullName = "Ivan Ivanov",
                        MobileTelephoneNumber = "+71111111111"
                    },
                    new DonationCandidate
                    {
                        Id = 2,
                        Address = "Russia",
                        Age = 46,
                        BloodGroupId = (int) EnumBloodGroup.O,
                        Email = "ipetrov@react.com",
                        FullName = "Ivan Petrov",
                        MobileTelephoneNumber = "+72222222222"
                    },
                    new DonationCandidate
                    {
                        Id = 3,
                        Address = "Mexico",
                        Age = 19,
                        BloodGroupId = (int) EnumBloodGroup.AB,
                        Email = "psidorov@react.com",
                        FullName = "Petr Sidorov",
                        MobileTelephoneNumber = "+73333333333"
                    }
                );

                dbContext.SaveChanges();
            }
        }
    }
}