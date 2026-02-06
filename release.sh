#! /usr/bin/env bash
set -uvx
set -e
rm -rf bin obj packages
dotnet restore MyApi.sln -p:Configuration=Release -p:Platform="Any CPU"
msbuild.exe MyApi.sln -p:Configuration=Release -p:Platform="Any CPU"
#dotnet build -c Release
#cp -rv bin/Release/net9.0/win-x64/* ~/cmd/
#cp -rv bin/Release/net481/win-x64/* ~/cmd/dotnet4/
cp -rv bin/Release/net481/* ~/cmd/
