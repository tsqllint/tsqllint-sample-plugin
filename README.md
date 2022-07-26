# TSQLLint Sample Plugin

This repo contains a sample solution and project which builds a TSQLLint plugin.

## Usage

Build the plugin

```
dotnet build tsqllint-sample-plugin.sln --output /tmp/tsqllint-plugin
```

Add a plugin object to your tsqllint config, usually located at `~/.tsqllintrc`

```
    "plugins": {
      "sample-plugin":"/tmp/tsqllint-plugin/tsqllint-sample-plugin.dll"
    }
```

Test the plugin

```bash
echo "   select 1;" > ~/Desktop/foo.sql && tsqllint ~/Desktop/foo.sql
```

You should see a message like the following

```
~/Desktop/foo.sql(1,-1): warning prefer-tabs : Should use spaces rather than tabs.
```
