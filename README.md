(ES|MS)Build
============
[![Build status](https://github.com/gulbanana/ESBuild.MSBuild/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/rustls/rustls/actions/workflows/build.yml?query=branch%3Amain)
[![NuGet package](https://img.shields.io/nuget/v/ESBuild.MSBuild.svg)](https://nuget.org/packages/ESBuild.MSBuild)

`ESBuild.MSBuild` is a NuGet package which wraps [esbuild](https://esbuild.github.io/), enabling frontend builds without Node or NPM.

Usage
-----
Add a package reference and `ESBuild` items to your csproj. Each entry point will be bundled and converted into a `Content` item, which will be published and (if you are using ASP.NET Core) included as a static web asset, accessible at `_content/<Your.Project.Name>/<bundle.name>`. Example:
```
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net7.0</TargetFramework>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="ESBuild.MSBuild" Version="0.19.4.11" />
		<ESBuild Include="index.ts" />
	</ItemGroup>
</Project>
```

API
---
For more complex scenarios, these MSBuild properties are available.
| Property                  | Description                              | Default                         | Purpose                                                                                           |
| ------------------------- | ---------------------------------------- | ------------------------------- | ------------------------------------------------------------------------------------------------- |
| `ESBuildBinaryPath`       | Location of `esbuild` or `esbuild.exe`.  | Platform-specific.              | For low-level integration - use it to run esbuild yourself, or change it to run a custom version. |                                        |
| `ESBuildIntermediatePath` | Location to write generated bundles.     | `obj/$(Configuration)/esbuild/` | Can be changed if you want to store the bundles or distribute them out-of-band.                   |
| `ESBuildWebRoot`          | Virtual path of generated Content items. | `wwwroot/`                      | Provides static web assets integration and the output path used for `dotnet publish`.             |
| `ESBuildArguments`        | Parameters passed to esbuild.            | `--bundle --minify`             | See [https://esbuild.github.io/api/](https://esbuild.github.io/api/) for available options.       |

Platforms
---------
The package contains esbuild binaries for MacOS, Windows and Linux (glibc), on AMD64 and ARM64.

Versions
--------
The first three digits of the package version are the version of the included esbuild, and the fourth digit is the package build number.