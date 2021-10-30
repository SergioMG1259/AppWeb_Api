using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
        {
            //Apply Naming Convention for Each Entity
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                //Apply Naming Convention for Each Property
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }
                //Apply Naming Convention for Each Key
                foreach (var key in entity.GetKeys()) key.SetName(key.GetName().ToSnakeCase());
                //Apply Naming Convention for Each ForeignKey
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                }
                //Apply Naming Convention for Indexes
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }
    }
}
