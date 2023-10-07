(ES|MS)Build
============
[![Build status](https://github.com/gulbanana/ESBuild.MSBuild/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/rustls/rustls/actions/workflows/build.yml?query=branch%3Amain)
[![NuGet package](https://img.shields.io/nuget/v/ESBuild.MSBuild.svg)](https://nuget.org/packages/ESBuild.MSBuild)

`ESBuild.MSBuild` is a NuGet package which wraps [esbuild](https://esbuild.github.io/), enabling frontend builds without Node or NPM.

Usage
-----
Add `<PackageReference Include="ESBuild.MSBuild" />` to your .csproj file. This will set the property `ESBuildPath`, which can be used directly for low-level integrations (for exmaple, by the Exec task). For high-level use, add `<EntryPoint>` items to your project, as in
```
<ItemGroup>
    <EntryPoint Include="index.js" />
</ItemGroup>
```
Each entry point will be copied to the output as a Bundle item.

Platforms
---------
The package contains esbuild binaries for MacOS, Windows and Linux (glibc), on AMD64 and ARM64.