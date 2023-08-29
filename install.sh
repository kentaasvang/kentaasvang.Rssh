#!/bin/bash
dotnet pack ./kentaasvang.Rssh
dotnet tool install kentaasvang.Rssh --global --add-source ./kentaasvang.Rssh/bin/Debug
