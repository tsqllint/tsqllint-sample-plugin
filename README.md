# tsqllint-sample-plugin
#Configuration steps for the MC Plugin
    1. Download the latest TSQLLint MC Plugin from: https://github.exacttarget.com/Platform/TSQLLint-MC-Plugin/releases and place it somewhere, perhaps "C:/Users/{YOUR_NAME}/tsqllintPlugins/"
    2. Figure out where your .tsqllintrc config file is located with the following command  tsqllint -p or, if necessary, generate a new one with tsqllint -i
    3. Edit your .tsqllintrc file to look something like the JSON at the bottom of this doc. be sure to update the plugin path to reflect where you placed the MC Plugin.
    4. check that the plugin is loaded successfully with tsqllint -l you should see a message stating that a plugin was found.

#Sample JSON with MC Plugin path
{
    "rules": {
        "conditional-begin-end": "error",
        "cross-database-transaction": "error",
        "data-compression": "error",
        "data-type-length": "error",
        "disallow-cursors": "error",
        "full-text": "error",
        "information-schema": "error",
        "keyword-capitalization": "error",
        "linked-server": "error",
        "multi-table-alias": "error",
        "named-constraint": "error",
        "non-sargable": "error",
        "object-property": "error",
        "print-statement": "error",
        "schema-qualify": "error",
        "select-star": "error",
        "semicolon-termination": "error",
        "set-ansi": "error",
        "set-nocount": "error",
        "set-quoted-identifier": "error",
        "set-transaction-isolation-level": "error",
        "set-variable": "warning",
        "upper-lower": "error",
        "unicode-string" : "error"   
    },
    "plugins": {
        "mc_plugin": "CHANGE_ME! C:/Users/{YOUR_NAME}/tsqllintPlugins/TSQLLint.MC.Plugin.dll"
    },
    "compatability-level": 130
}
