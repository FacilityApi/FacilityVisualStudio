# Facility Visual Studio

Visual Studio extension for working with the [Facility API Framework](https://facilityapi.github.io/).

## Publishing

* Make any necessary modifications to `src\Facility.VisualStudioExtension\Grammars\fsd.tmLanguage`.
* Copy `Facility.LanguageServer.exe` from the latest `win-x64` release in [FacilityApi/FacilityLanguageServer](https://github.com/FacilityApi/FacilityLanguageServer/releases) to `src\Facility.VisualStudioExtension\Server`.
* Open the solution and debug the extension from Visual Studio to confirm the correct behavior.
* Bump the versions in `src\Facility.VisualStudioExtension\source.extension.vsixmanifest` and `src\Facility.VisualStudioExtension\Properties\AssemblyInfo.cs`.
* Update `ReleaseNotes.md` accordingly.
* Switch to the `Release` `Any CPU` configuration and build the extension.
* Follow the [instructions](https://learn.microsoft.com/en-us/visualstudio/extensibility/walkthrough-publishing-a-visual-studio-extension?view=vs-2022#update-a-published-extension-in-visual-studio-marketplace) to publish the extension. Be sure to update the Visual Studio extension, not the Visual Studio Code extension.
