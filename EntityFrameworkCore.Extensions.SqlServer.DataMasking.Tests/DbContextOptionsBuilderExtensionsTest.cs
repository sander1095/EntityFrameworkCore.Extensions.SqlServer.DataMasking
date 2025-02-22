﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking.Tests;

public class DbContextOptionsBuilderExtensionsTest
{
    [Fact]
    public void UseEntityFrameworkCoreExtensions_should_register_necessary_services()
    {
        var builder = new DbContextOptionsBuilder<TestContext>()
            .UseSqlServer("fake")
            .UseEntityFrameworkCoreExtensions()
            .Options;
        var context = (IInfrastructure<IServiceProvider>)new TestContext(builder);

        var migrationSqlGenerator = context.GetService<IMigrationsSqlGenerator>();
        var relationalAnnotationProvider = context.GetService<IRelationalAnnotationProvider>();

        Assert.IsType<ExtendedSqlServerMigrationsSqlGenerator>(migrationSqlGenerator);
        Assert.IsType<ExtendedSqlServerAnnotationProvider>(relationalAnnotationProvider);
    }
}