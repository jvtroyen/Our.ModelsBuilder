﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Our.ModelsBuilder.Api;
using Our.ModelsBuilder.Building;
using Our.ModelsBuilder.Options;
using Our.ModelsBuilder.Options.ContentTypes;
using Our.ModelsBuilder.Tests.Testing;

namespace Our.ModelsBuilder.Tests.Write
{
    [TestFixture]
    public class WriteInfosTests : TestsBase
    {
        [Test]
        public void WriteSimpleTypesInfos()
        {
            // Umbraco returns nice, pascal-cased names

            var codeModelData = new CodeModelData();

            var type1 = new ContentTypeModel
            {
                Id = 1,
                Alias = "type1",
                ParentId = 0,
                BaseContentType = null,
                Kind = ContentTypeKind.Content,
            };
            codeModelData.ContentTypes.Add(type1);
            type1.Properties.Add(new PropertyTypeModel
            {
                Alias = "prop1",
                ContentType = type1,
                ValueType = typeof(string),
            });

            var type2 = new ContentTypeModel
            {
                Id = 2,
                Alias = "type2",
                ParentId = 0,
                BaseContentType = null,
                Kind = ContentTypeKind.Content,
            };
            codeModelData.ContentTypes.Add(type2);
            type2.Properties.Add(new PropertyTypeModel
            {
                Alias = "prop1",
                ContentType = type2,
                ValueType = typeof(string),
            });
            type2.Properties.Add(new PropertyTypeModel
            {
                Alias = "prop2",
                ContentType = type2,
                ValueType = typeof(global::System.Web.IHtmlString),
            });
            type2.Properties.Add(new PropertyTypeModel
            {
                Alias = "prop3",
                ContentType = type2,
                ValueType = typeof(string),
            });

            var type3 = new ContentTypeModel
            {
                Id = 3,
                Alias = "type3",
                ParentId = 0,
                BaseContentType = null,
                Kind = ContentTypeKind.Media,
            };
            codeModelData.ContentTypes.Add(type3);

            var sources = new Dictionary<string, string>();

            // note: this is *not* the default expected header!
            var version = ApiVersion.Current.Version;
            var expected = @"//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Our.ModelsBuilder v" + version + @"
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Our.ModelsBuilder;
using Our.ModelsBuilder.Umbraco;
using System.Linq;
using System.CodeDom.Compiler;

namespace Umbraco.Web.PublishedModels
{
    /// <summary>Provides information about models.</summary>
    public static partial class ModelInfos
    {
        /// <summary>Gets the name of the generator.</summary>
        public const string Name = ""Our.ModelsBuilder"";

        /// <summary>Gets the version of the generator that generated the files.</summary>
        public const string VersionString = """ + version + @""";

        /// <summary>Provides information about content type models.</summary>
        public static class ContentTypes
        {
            /// <summary>Provides information about the Type1 content type.</summary>
            public static class Type1
            {
                /// <summary>Gets the item type of the content type.</summary>
                public const PublishedItemType ItemType = PublishedItemType.Content;

                /// <summary>Gets the alias of the content type.</summary>
                public const string Alias = ""type1"";

                /// <summary>Gets the content type.</summary>
                public static IPublishedContentType GetContentType() => PublishedModelUtility.GetModelContentType(ItemType, Alias);

                /// <summary>Provides information about the properties of the Type1 content type.</summary>
                public static class Properties
                {
                    /// <summary>Provides information about the Prop1 property type.</summary>
                    public static class Prop1
                    {
                        /// <summary>Gets the alias of the property type.</summary>
                        public const string Alias = ""prop1"";

                        /// <summary>Gets the property type.</summary>
                        public static IPublishedPropertyType GetPropertyType() => GetContentType().GetPropertyType(Alias);
                    }
                }
            }

            /// <summary>Provides information about the Type2 content type.</summary>
            public static class Type2
            {
                /// <summary>Gets the item type of the content type.</summary>
                public const PublishedItemType ItemType = PublishedItemType.Content;

                /// <summary>Gets the alias of the content type.</summary>
                public const string Alias = ""type2"";

                /// <summary>Gets the content type.</summary>
                public static IPublishedContentType GetContentType() => PublishedModelUtility.GetModelContentType(ItemType, Alias);

                /// <summary>Provides information about the properties of the Type2 content type.</summary>
                public static class Properties
                {
                    /// <summary>Provides information about the Prop1 property type.</summary>
                    public static class Prop1
                    {
                        /// <summary>Gets the alias of the property type.</summary>
                        public const string Alias = ""prop1"";

                        /// <summary>Gets the property type.</summary>
                        public static IPublishedPropertyType GetPropertyType() => GetContentType().GetPropertyType(Alias);
                    }

                    /// <summary>Provides information about the Prop2 property type.</summary>
                    public static class Prop2
                    {
                        /// <summary>Gets the alias of the property type.</summary>
                        public const string Alias = ""prop2"";

                        /// <summary>Gets the property type.</summary>
                        public static IPublishedPropertyType GetPropertyType() => GetContentType().GetPropertyType(Alias);
                    }

                    /// <summary>Provides information about the Prop3 property type.</summary>
                    public static class Prop3
                    {
                        /// <summary>Gets the alias of the property type.</summary>
                        public const string Alias = ""prop3"";

                        /// <summary>Gets the property type.</summary>
                        public static IPublishedPropertyType GetPropertyType() => GetContentType().GetPropertyType(Alias);
                    }
                }
            }

            /// <summary>Provides information about the Type3 content type.</summary>
            public static class Type3
            {
                /// <summary>Gets the item type of the content type.</summary>
                public const PublishedItemType ItemType = PublishedItemType.Media;

                /// <summary>Gets the alias of the content type.</summary>
                public const string Alias = ""type3"";

                /// <summary>Gets the content type.</summary>
                public static IPublishedContentType GetContentType() => PublishedModelUtility.GetModelContentType(ItemType, Alias);

                /// <summary>Provides information about the properties of the Type3 content type.</summary>
                public static class Properties
                {
                }
            }
        }

        /// <summary>Gets the content type model infos.</summary>
        [GeneratedCodeAttribute(Name, VersionString)]
        public static IReadOnlyCollection<ContentTypeModelInfo> ContentTypeInfos => _contentTypeInfos;

        /// <summary>Gets the model infos for a content type.</summary>
        [GeneratedCodeAttribute(Name, VersionString)]
        public static ContentTypeModelInfo GetContentTypeInfos(string alias) => _contentTypeInfos.FirstOrDefault(x => x.Alias == alias);

        /// <summary>Gets the model infos for a content type.</summary>
        [GeneratedCodeAttribute(Name, VersionString)]
        public static ContentTypeModelInfo GetContentTypeInfos<TModel>() => _contentTypeInfos.FirstOrDefault(x => x.ClrType == typeof(TModel));

        /// <summary>Gets the model infos for a content type.</summary>
        [GeneratedCodeAttribute(Name, VersionString)]
        public static ContentTypeModelInfo GetContentTypeInfos(Type typeofModel) => _contentTypeInfos.FirstOrDefault(x => x.ClrType == typeofModel);

        [GeneratedCodeAttribute(Name, VersionString)]
        private static readonly ContentTypeModelInfo[] _contentTypeInfos = 
        {
            new ContentTypeModelInfo(""type1"", ""Type1"", typeof(Type1),
                new PropertyTypeModelInfo(""prop1"", ""Prop1"", typeof(string))),
            new ContentTypeModelInfo(""type2"", ""Type2"", typeof(Type2),
                new PropertyTypeModelInfo(""prop1"", ""Prop1"", typeof(string)),
                new PropertyTypeModelInfo(""prop2"", ""Prop2"", typeof(IHtmlString)),
                new PropertyTypeModelInfo(""prop3"", ""Prop3"", typeof(string))),
            new ContentTypeModelInfo(""type3"", ""Type3"", typeof(Type3))
        };
    }
}
";

            var codeModelBuilder = new CodeModelBuilder(new ModelsBuilderOptions(), new CodeOptions(new ContentTypesCodeOptions()));
            var codeModel = codeModelBuilder.Build(codeModelData);
            var writer = new CodeWriter(codeModel);

            writer.WriteModelInfosFile();
            var generated = writer.Code;

            Console.WriteLine(generated);
            Assert.AreEqual(expected.ClearLf(), generated);

            sources["modelInfos"] = generated;
            for (var i = 0; i < codeModel.ContentTypes.ContentTypes.Count; i++)
            {
                writer.Reset();
                writer.WriteModelFile(codeModel.ContentTypes.ContentTypes[i]);
                sources["ourFile" + i] = writer.Code;
            }

            AssertCode.Compiles(sources);
        }
    }
}
