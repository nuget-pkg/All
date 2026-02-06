#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

cd $cwd
rm -rf src
mkdir src

cd $cwd
rm -rf tmp
mkdir tmp

cd $cwd/tmp

git clone --recursive https://github.com/nuget-pkg/PlainObjectInterface
cp -rv PlainObjectInterface/PlainObjectInterface $cwd/src/

git clone --recursive https://github.com/nuget-pkg/CommonJsonInterface
cp -rv CommonJsonInterface/CommonJsonInterface $cwd/src/

git clone --recursive https://github.com/nuget-pkg/JsoncParser
cp -rv JsoncParser/JsoncParser $cwd/src/

git clone --recursive https://github.com/nuget-pkg/EasyObject
cp -rv EasyObject/EasyObject $cwd/src/

git clone --recursive https://github.com/nuget-pkg/Internals
cp -rv Internals $cwd/src/
