using System.ComponentModel.Composition;
using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;

namespace Facility.VisualStudioExtension
{
	public class FacilityContentDefinition
	{
		[Export]
		[Name("fsd")]
		[BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
		internal static ContentTypeDefinition FsdContentTypeDefinition;

		[Export]
		[FileExtension(".fsd")]
		[ContentType("fsd")]
		internal static FileExtensionToContentTypeDefinition FsdFileExtensionDefinition;
	}
}
