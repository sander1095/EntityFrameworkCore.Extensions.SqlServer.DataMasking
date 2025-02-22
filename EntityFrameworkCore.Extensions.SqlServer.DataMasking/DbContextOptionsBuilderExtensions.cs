﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking;

public static class DbContextOptionsBuilderExtensions
{
    /// <summary>
    /// Register services necessary for enabling dynamic data masking (and more features in the future)
    /// </summary>
    public static DbContextOptionsBuilder UseEntityFrameworkCoreExtensions(this DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ReplaceService<IMigrationsSqlGenerator, ExtendedSqlServerMigrationsSqlGenerator>();
        optionsBuilder.ReplaceService<IRelationalAnnotationProvider, ExtendedSqlServerAnnotationProvider>();

        return optionsBuilder;
    }
}