using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal;

namespace SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking;

public class ExtendedSqlServerAnnotationProvider(RelationalAnnotationProviderDependencies dependencies) : SqlServerAnnotationProvider(dependencies)
{
    public override IEnumerable<IAnnotation> For(IColumn column, bool designTime)
    {
        foreach (var annotation in base.For(column, designTime))
        {
            yield return annotation;
        }

        var properties = column.PropertyMappings.Select(m => m.Property);
        var annotations = properties.SelectMany(p => p.GetAnnotations()).GroupBy(a => a.Name).Select(g => g.First());

        foreach (var annotation in annotations.Where(x => x.Name == AnnotationConstants.DynamicDataMasking))
        {
            yield return annotation;
        }
    }
}