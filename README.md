(ES|MS)Build
============
[![Build status](https://github.com/gulbanana/ESBuild.MSBuild/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/rustls/rustls/actions/workflows/build.yml?query=branch%3Amain)
[![NuGet package](https://img.shields.io/nuget/v/ESBuild.MSBuild.svg)](https://nuget.org/packages/ESBuild.MSBuild)

`ESBuild.MSBuild` is a NuGet package which wraps [esbuild](https://esbuild.github.io/), enabling frontend builds without Node or NPM.

Usage
-----
Add a package reference and `ESBuild` items to your csproj. Each entry point will be bundled and converted into a `Content` item, which will be published and (if you are using ASP.NET Core) included as a static web asset, accessible at `_content/<Your.Project.Name>/<bundle.name>`. Example:
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
    <PropertyGroup>
        <TargetFramework>net7.0</TargetFramework>
    </PropertyGroup>
    
    <ItemGroup>
        <PackageReference Include="ESBuild.MSBuild" Version="0.19.4.*" />
        <ESBuild Include="index.ts" Minify="true" />
        <ESBuild Include="app.css" />
        <ESBuild Include="global/*.css" Group="global.css" />
    </ItemGroup>
</Project>
```

API
---
For more complex scenarios, these MSBuild properties are available.

| Property                  | Default                         | Description                              | Purpose                                                                                           |
| ------------------------- | ------------------------------- | ---------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `ESBuildBinaryPath`       | Platform-specific.              | Location of `esbuild` or `esbuild.exe`.  | For low-level integration - use it to run esbuild yourself, or change it to run a custom version. |
| `ESBuildEcho`             | `False`                         | Whether to log esbuild invocations.      | Set to true to display generated commandlines.                                                    |
| `ESBuildIntermediatePath` | `obj/$(Configuration)/esbuild/` | Location to write generated bundles.     | Can be changed if you want to store the bundles or distribute them out-of-band.                   |
| `ESBuildWebRoot`          | `wwwroot/`                      | Virtual path of generated Content items. | Provides static web assets integration and the output path used for `dotnet publish`.             |

Bundling can be configured with properties or item metadata 

| Global property      | Item metadata | Default                          | Description                                                                                          |
| -------------------- | ------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------- |
| n/a                  | `Group`       | None.                            | ESBuild items with the same Group will be concatenated together before bundling.                     |
| `ESBuildArguments`   | `Arguments`   | None.                            | Overrides all other config. (See [esbuild docs](https://esbuild.github.io/api/).)                    |
| `ESBuildBundle`      | `Bundle`      | `True`                           | Inline any imported dependencies into the output file.                                               |
| `ESBuildExternals`   | `Externals`   | None                             | Semicolon-separated list of external packages that don't require resolution.                         |
| `ESBuildFormat`      | `Format`      | [Automatic](https://esbuild.github.io/api/#format). | `iife`, `esm` or `cjs`.                                                           |
| `ESBuildMinify`      | `Minify`      | `True` in Release configuration. | Rewrite syntax to be more compact. Takes advantage of all features allowed by Targets.               |
| `ESBuildPlatform`    | `Platform`    | `browser`                        | `browser`, `node` or `neutral`.                                                                      |
| `ESBuildTargets`     | `Targets`     | `esnext`                         | Semicolon-separated list of required support levels. (Unlike `--targets`, which is comma-separated). |
| `ESBuildTreeShaking` | `TreeShaking` | [Automatic](https://esbuild.github.io/api/#tree-shaking). | `True` to force-enable or `False` to force-disable dead code elimination.   |


Platforms
---------
The package contains esbuild binaries for MacOS, Windows and Linux (glibc), on AMD64 and ARM64.

Versions
--------
The first three digits of the package version are the version of the included esbuild, and the fourth digit is the package build number.