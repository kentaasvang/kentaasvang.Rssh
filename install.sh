#!/bin/bash
dotnet pack src/kentaasvang.Rssh
dotnet tool install kentaasvang.Rssh --global --add-source src/kentaasvang.Rssh/bin/Debug
