# 🆕 Remember SSH - rssh

## ❓ What is My Project?
Got sick and tired of looking up login credentials for a few dozen ubuntu servers so I created this CLI to get a common interface to all of them.

## ⚡ Doc's

**Install**
dotnet pack
dotnet tool install Kent.Cli.Rssh --global --add-source bin/Debug

**Update**
dotnet pack
dotnet tool update Kent.Cli.Rssh --global --add-source bin/Debug

**Delete**
dotnet tool uninstall Kent.Cli.Rssh --global

**Migrate and update database**
dotnet ef migrations add <migration name>
dotnet ef database update


### 🔨 API

**Add a server**
```shell
rssh add <servername>
```

**Delete a server**
```shell
rssh remove <servername>
```

**Add a server from a group**
```shell
rssh add <servername> --group <groupname>
```

**Delete a server from a group**
```shell
rssh remove <servername> --group <groupname>
```

**Delete a group**
```shell
rssh remove --group <groupname>
```

**List connections**
```shell
rssh list
```

**List connections from group**
```shell
rssh list --group <groupname>
```

## 🤝 Collaborate with My Project
Sure. Go ahead. submit PR's like there's no tomorrow. Filing issues to tell me I'm an idiot is allowed but not encouraged.

