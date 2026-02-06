#! /usr/bin/env bash
set -uvx
set -e
rm -rf bin obj packages
dotnet restore MyApi.sln -p:Configuration=Release -p:Platform="Any CPU"
msbuild.exe MyApi.sln -p:Configuration=Release -p:Platform="Any CPU"
cp -rv bin/Release/net462/* ~/cmd/
