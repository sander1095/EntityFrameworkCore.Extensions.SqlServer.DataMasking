// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Needs to be done for this package to work", Scope = "type", Target = "~T:SanderTenBrinke.EntityFrameworkCore.Extensions.ExtendedSqlServerAnnotationProvider")]
[assembly: SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Needs to be done for this package to work", Scope = "type", Target = "~T:SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking.ExtendedSqlServerAnnotationProvider")]
